using ISDb.Application.Mssql;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Core.UserAuth
{
    public class UserAuthModel : BaseMssqlModel
    {
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }

    }
}
