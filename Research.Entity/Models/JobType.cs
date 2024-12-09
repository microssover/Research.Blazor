using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Entity.Models
{
    public partial class JobType
    {
        public Guid ID { get; set; }
        public string? DESC { get; set; }
        public Guid DEPARTMENT_ID { get; set; }
        public Guid? FLOW_ID { get; set; }
        public virtual Department Department { get; set; }
        public virtual ApplicantFlow ApplicantFlow { get; set; }
        public virtual ICollection<ApplicantRecords> ApplicantRecords { get; set; }

    }
}
