using System.Net;
using LearningPlatform.Application.Contracts.Identity;
using LearningPlatform.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(IAuthService authService,
        ILogger<AccountController> logger,
        IRoleService roleService,
        IUserService userService)
    {
        _authService = authService;
        _logger = logger;
        _roleService = roleService;
        _userService = userService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(AuthRequest request)
    {
        var result = await _authService.Login(request);
        if (result.HasError)
        {
            return BadRequest(result);
        }
        return Ok(result);

    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        
        var result = await _authService.Register(request);
        if (result.HasError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost("LockOut")]
    public async Task<IActionResult> LockOut(LockOutRequest request)
    {
        var result = await _userService.LockUser(request);
        if (result.HasError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost("EndLockOut")]
    public async Task<IActionResult> EndLockOut(LockOutRequest request)
    {
        var result = await _userService.EndUserLockOut(request);
        if (result.HasError)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
