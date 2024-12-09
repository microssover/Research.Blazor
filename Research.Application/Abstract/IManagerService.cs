using Research.Dto.DTO;

namespace Research.Application.Abstract
{
    public interface IManagerService
    {
        Task<bool> Create(ManagerDTO ManagerDTO);
        Task<bool> Delete(Guid id);
        Task<List<ManagerDTO>> GetAll();
        Task<List<ManagerDTO>> GetManagers();
        Task<ManagerDTO> GetById(Guid id);
        Task<bool> Update(ManagerDTO ManagerDTO);

    }
}
