using ISDb.Domain.Mssql.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ISDb.Domain.Mssql.Poco
{
    public class UserAuth : Entity
    {
        [Key]
        [StringLength(100)]
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserAuth")]
        public virtual User User { get; set; }
    }
}
