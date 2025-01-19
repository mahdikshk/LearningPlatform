using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Identity;
using LearningPlatform.Persistance.Models;
using Microsoft.AspNetCore.Identity;

namespace LearningPlatform.Persistance.Services;
internal class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task AddRole(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role is not null)
        {
            return;
        }
        var newRole = new ApplicationRole()
        {
            Name = roleName,
        };
        var result = await _roleManager.CreateAsync(newRole);
    }

    public async Task AddToRole(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return;
        }
        var result = await _userManager.AddToRoleAsync(user, roleName);
        if(!result.Succeeded)
        {
            return;
        }
    }

    public async Task RemoveFromRole(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return;
        }
        var result = await _userManager.RemoveFromRoleAsync(user, role);
        if (!result.Succeeded)
        {
            return;
        }
    }

    public async Task DeleteRole(string role)
    {
        var foundRole = await _roleManager.FindByNameAsync(role);
        if (foundRole is null)
        {
            return;
        }
        var result = await _roleManager.DeleteAsync(foundRole);
    }
}
