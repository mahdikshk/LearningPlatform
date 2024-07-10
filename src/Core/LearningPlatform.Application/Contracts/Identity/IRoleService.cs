using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Application.Contracts.Identity;
public interface IRoleService
{
    public Task AddToRole(string userId, string roleName);
    public Task RemoveFromRole(string userId, string role);
    public Task AddRole(string roleName);
    public Task DeleteRole(string role);
    //public 
}
