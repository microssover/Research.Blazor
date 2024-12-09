namespace Research.Dto.DTO
{
    public class DepartmentDTO
    {
        public Guid Id { get; set; } 
        public string? Name { get; set; }
        public Guid? Manager_Id { get; set; }
        public ManagerDTO? ManagerDTO { get; set; }
    }
}
