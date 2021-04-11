using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISDb.Application.Core.UserAuth
{
    public interface IUserAuthService
    {
        Task<UserAuthModel> CreateUserAuth(UserAuthModel userAuthModel);
        Task<bool> CheckIsUserAdmin(string userId);
    }
}
