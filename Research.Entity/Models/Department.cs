using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Entity.Models
{
    public partial class Department
    {
        public Guid ID { get; set; }
        public string? NAME { get; set; }
        public Guid? MANAGER_ID { get; set; }
        public ICollection<JobType> JobTypes { get; set; }
        public virtual Manager Manager { get; set; }
        public ICollection<ApplicantFlow> Applicant_Flows { get; set; }

    }
}
