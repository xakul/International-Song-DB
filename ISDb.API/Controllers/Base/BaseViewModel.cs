using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISDb.API.Controllers.Base
{
    public abstract class BaseViewModel
    {
        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string ChangedBy { get; set; }

        public DateTime? ChangedAt { get; set; }
    }
}
