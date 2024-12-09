using Research.Dto.DTO;

namespace Research.Blazor.UI.Services.Abstract
{
    public interface IJobTypeService
    {
        Task<bool> Create(JobTypeDTO JobTypeDTO);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<JobTypeDTO>?> GetAll();
        Task<IEnumerable<JobTypeDTO>?> GetJobTypes();
        Task<JobTypeDTO?> GetById(Guid id);
        Task<bool> Update(JobTypeDTO JobTypeDTO);
    }
}
