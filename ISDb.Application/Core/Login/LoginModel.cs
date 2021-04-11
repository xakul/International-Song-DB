using ISDb.Application.Mssql;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Core.Login
{
    public class LoginModel : BaseMssqlModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
    }
}
