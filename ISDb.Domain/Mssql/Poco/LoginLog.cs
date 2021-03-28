using ISDb.Domain.Mssql.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ISDb.Domain.Mssql.Poco
{
    public class LoginLog : Entity
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string UserId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("LoginLogs")]
        public virtual User User { get; set; }
    }
}
