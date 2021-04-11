using ISDb.Application.Mssql;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Core.User
{
    public class UserModel : BaseMssqlModel
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
