using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Identity;
using LearningPlatform.Application.Models.Identity;
using LearningPlatform.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace LearningPlatform.Identity.Services;

internal class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    #region LockOut

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<LockOutResponse> LockUser(LockOutRequest request)
    {
        return PerformLockout(request, true);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<LockOutResponse> EndUserLockOut(LockOutRequest request)
    {
        return PerformLockout(request, false);
    }

    private async Task<LockOutResponse> PerformLockout(LockOutRequest request, bool LockOut)
    {
        if (request.Id is not null)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user is null)
            {
                return new LockOutResponse()
                {
                    HasError = true,
                    ErrorMessage = "کاربر وارد شده وجود ندارد"
                };
            }
            var result = await _userManager.SetLockoutEnabledAsync(user, LockOut);
            if (!result.Succeeded)
            {
                return new LockOutResponse()
                {
                    HasError = true,
                    ErrorMessage = "عملیات موفقیت آمیز نبود"
                };
            }

            return new LockOutResponse()
            {
                IsSuccessfull = true
            };
        }
        else if(request.Email is not null)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return new LockOutResponse()
                {
                    HasError = true,
                    ErrorMessage = "کاربری با این ایمیل وجود ندارد"
                };
            }
            var result = await _userManager.SetLockoutEnabledAsync(user, LockOut);
            if (!result.Succeeded)
            {
                return new LockOutResponse()
                {
                    HasError = true,
                    ErrorMessage = "عملیات با شکست مواجه شده"
                };
            }

            return new LockOutResponse()
            {
                IsSuccessfull = true
            };

        }

        return new LockOutResponse()
        {
            HasError = true,
            ErrorMessage = "آیدی یا ایمیل معتبر وارد کنید"
        };
    }

    #endregion
    
    public async Task<UserNameResponse> GetFirstNameAndLastName(UserNameRequest request)
    {
        if (request.Id is not null)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user is null)
            {
                return new UserNameResponse()
                {
                    HasError = true,
                    ErrorMessage = "کاربری با این آیدی وجود ندارد"
                };
            }

            return new UserNameResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
        else if (request.Email is not null)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return new UserNameResponse()
                {
                    HasError = true,
                    ErrorMessage = "کاربری با این ایمیل وجود ندارد"
                };
            }

            return new UserNameResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        return new UserNameResponse()
        {
            HasError = true,
            ErrorMessage = "آیدی یا ایمیل را وارد نمایید"
        };
    }
    
    
}