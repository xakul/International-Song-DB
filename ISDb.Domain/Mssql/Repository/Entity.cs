using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TrackableEntities.Common.Core;

namespace ISDb.Domain.Mssql.Repository
{
    public abstract class Entity : ITrackable, IMergeable
    {
        [NotMapped]
        public TrackingState TrackingState { get; set; }

        [NotMapped]
        public ICollection<string> ModifiedProperties { get; set; }

        [NotMapped]
        public Guid EntityIdentifier { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [StringLength(100)]
        public string ChangedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ChangedAt { get; set; }
    }
}
