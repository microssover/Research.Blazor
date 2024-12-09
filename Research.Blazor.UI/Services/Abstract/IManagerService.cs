using Research.Dto.DTO;

namespace Research.Blazor.UI.Services.Abstract
{
    public interface IManagerService
    {
        Task<bool> Create(ManagerDTO ManagerDTO);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<ManagerDTO>?> GetAll();
        Task<IEnumerable<ManagerDTO>?> GetManagers();
        Task<ManagerDTO?> GetById(Guid id);
        Task<bool> Update(ManagerDTO ManagerDTO);
    }
}
