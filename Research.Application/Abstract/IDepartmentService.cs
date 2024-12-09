using Research.Dto.DTO;

namespace Research.Application.Abstract
{
    public interface IDepartmentService 
    {
        Task<bool> Create(DepartmentDTO DepartmentDTO);
        Task<bool> Update(DepartmentDTO DepartmentDTO);
        Task<bool> Delete(Guid id);
        Task<List<DepartmentDTO>> GetAll();
        Task<List<DepartmentDTO>> GetDepartments();
        Task<DepartmentDTO> GetById(Guid id);
    }
}
