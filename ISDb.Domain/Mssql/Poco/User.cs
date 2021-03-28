using ISDb.Domain.Mssql.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ISDb.Domain.Mssql.Poco
{
    public partial class User : Entity
    {
        public User()
        {
            LoginLogs = new HashSet<LoginLog>();
        }

        [Key]
        [StringLength(100)]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty(nameof(LoginLog.User))]
        public virtual ICollection<LoginLog> LoginLogs { get; set; }
    }
}
