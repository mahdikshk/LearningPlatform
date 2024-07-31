using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Models.Identity;

namespace LearningPlatform.Application.Contracts.Identity;
public interface IUserService
{
    public Task<LockOutResponse> LockUser(LockOutRequest request);
    public Task<LockOutResponse> EndUserLockOut(LockOutRequest request);
    public Task<UserNameResponse> GetFirstNameAndLastName(UserNameRequest request);
    public Task<UserExistanceResponse> GetUserExistanceState(UserExistanceRequest request);
}
