using Research.Dto.DTO;

namespace Research.Application.Abstract
{
    public interface IJobTypeService
    {
         Task<bool> Create(JobTypeDTO JobTypeDTO);
         Task<bool> Delete (Guid id);
         Task<List<JobTypeDTO>> GetAll();
         Task<List<JobTypeDTO>> GetJobTypes();
         Task<JobTypeDTO> GetById(Guid id);
         Task<bool> Update(JobTypeDTO JobTypeDTO);

    }
}
