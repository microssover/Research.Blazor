using Research.Dto.DTO;

namespace Research.Blazor.UI.Services.Abstract
{
    public interface IDepartmentService
    {
        Task<bool> Create(DepartmentDTO DepartmentDTO);
        Task<bool> Update(DepartmentDTO DepartmentDTO);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<DepartmentDTO>?> GetAll();
        Task<IEnumerable<DepartmentDTO>?> GetDepartments();
        Task<DepartmentDTO?> GetById(Guid id);
    }
}
