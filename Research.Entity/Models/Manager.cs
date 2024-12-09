using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Entity.Models
{
    public class Manager
    {
        public Guid ID { get; set; }
        public string? NAME { get; set; }
        public string? SURNAME { get; set; }
        public virtual Department Department { get; set; }
    }
}
