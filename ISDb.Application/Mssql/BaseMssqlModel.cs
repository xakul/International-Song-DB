using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Mssql
{
    public abstract class BaseMssqlModel
    {
        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string ChangedBy { get; set; }

        public DateTime? ChangedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
