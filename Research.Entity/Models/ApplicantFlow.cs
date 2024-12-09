namespace Research.Entity.Models
{
    public partial class ApplicantFlow
    {
        public string NAME { get; set; }
        public Guid ID { get; set; }
        public Guid? NEXT_FLOW_ID { get; set; }
        public Guid? DEPARTMENT_ID { get; set; }
        public virtual Department Department { get; set; }
        public ICollection<ApplicantRecords> Applicant_Records{ get; set; }
        public ICollection<JobType> JobTypes{ get; set; }
    }
}
