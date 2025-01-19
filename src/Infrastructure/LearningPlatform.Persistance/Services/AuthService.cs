using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Constants;
using LearningPlatform.Application.Contracts.Identity;
using LearningPlatform.Application.Models.Identity;
using LearningPlatform.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LearningPlatform.Persistance.Services;
internal class AuthService : IAuthService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtSettings _jwtSettings;

    public AuthService(SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
    }
    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userManager.FindByEmailAsync(email: request.Email);
        if (user is null)
        {
            return new AuthResponse()
            {
                HasError = true,
                Error = "کاربر مورد نظر وجود ندارد"
            };
        }
        var result = await _signInManager.PasswordSignInAsync(user: user,
            password: request.Password,
            isPersistent: false,
            lockoutOnFailure: false);

        if (!result.Succeeded)
        {
            return new AuthResponse()
            {
                HasError = true,
                Error = "ایمیل یا رمز عبور وارد شده اشتباه است"
            };
        }
        var jwtSecurityToken = await GenerateToken(user: user);
        AuthResponse response = new()
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            UserName = user.UserName,
            HasError = false,
            Error = null
        };

        return response;
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.UserName);
        if (existingUser is not null)
        {
            return new RegistrationResponse()
            {
                HasError = true,
                Error = "کاربری با ایمیل وارد شما وجود دارد"
            };
        }

        var existingEmail = await _userManager.FindByEmailAsync(request.Email);
        if (existingEmail == null)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                return new RegistrationResponse()
                {
                    HasError = true,
                    Error = $"{result.Errors}"
                };
            }
        }
        else
        {
            return new RegistrationResponse()
            {
                HasError = true,
                Error = $"Email '{request.Email}' already exists."
            };
        }
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var userClaims = await _userManager.GetClaimsAsync(user);

        List<Claim> roleClaims = [];
        for (int i = 0; i < roles.Count; i++)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
        }

        List<Claim> claims =
        [
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomClaimTypes.Uid,user.Id),
                .. roleClaims,
                .. userClaims,
        ];

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }
}
