namespace Research.Dto.DTO
{
    public class ApplicantFlowDTO
    {
        public string? Name { get; set; }
        public Guid Id { get; set; }
        public Guid? Next_Flow_Id { get; set; }
        public Guid? Department_Id { get; set; }
        public DepartmentDTO? DepartmentDto { get; set; }
    }
}
