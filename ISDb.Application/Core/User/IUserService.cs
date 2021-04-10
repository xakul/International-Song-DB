using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISDb.Application.Core.User
{
    public interface IUserService
    {
        Task<UserModel> CreateUser(UserModel userModel);
        Task<UserModel> LoginControl(string email, string password);
    }
}
