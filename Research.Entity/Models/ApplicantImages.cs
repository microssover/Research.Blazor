using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Entity.Models
{
    public partial class ApplicantImages
    {
        public Guid ID { get; set; }
        public Guid? APPLICANT_ID { get; set; }
        public string? PATH { get; set; }
        public virtual ApplicantRecords Applicant_Records { get; set; }
    }
}
