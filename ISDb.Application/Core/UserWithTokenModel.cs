using ISDb.Application.Core.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Core
{
   public class UserWithTokenModel : UserModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithTokenModel(UserModel userModel)
        {
            this.Id = userModel.Id;
            this.Email = userModel.Email;
            this.IsAdmin = userModel.IsAdmin;

        }
    }
}
