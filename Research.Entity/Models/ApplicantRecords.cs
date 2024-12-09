using Research.Common.Enums;

namespace Research.Entity.Models
{
    public partial class ApplicantRecords
    {
        public Guid ID { get; set; }
        public string? NAME { get; set; }
        public string? SURNAME { get; set; }
        public string? EMAIL { get; set; }
        public byte[] PROFILE_IMAGE { get; set; }
        public ApplicantRecordFlow Status { get; set; }
        public string? JOB_TYPE { get; set; }
        public DateTime APPLICANT_DATE { get; set; }
        public Guid? CURRENT_FLOW_ID { get; set; }
        public Guid? JobTypeID { get; set; }
        public virtual ApplicantFlow Applicant_Flow { get; set; }
        public virtual JobType JobType { get; set; }
        public ICollection<ApplicantImages> Applicant_Images { get; set; }
    }
   
}
