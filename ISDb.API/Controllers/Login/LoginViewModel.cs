using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISDb.API.Controllers.Login
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }

    }
}
