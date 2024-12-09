using AutoMapper;
using Research.Application.Abstract;
using Research.Dto.DTO;
using Research.Entity.Models;
using Research.Infrastructure.DA.Abstract;

namespace Research.Application.Contract
{
    public class JobTypeService : IJobTypeService
    {
        private readonly IJobTypeDal _jobTypeDal;
        private IMapper _mapper;
        public JobTypeService(IJobTypeDal jobTypeDal, IMapper mapper)
        {
            _jobTypeDal = jobTypeDal;
            _mapper = mapper;
        }

        public async Task<bool> Create(JobTypeDTO JobTypeDTO)
        {
            var jobType = _mapper.Map<JobType>(JobTypeDTO);
            return await _jobTypeDal.CreateJobType(jobType);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _jobTypeDal.Delete(id);
        }

        public async Task<List<JobTypeDTO>> GetAll()
        {
            var jobType = await _jobTypeDal.GetAll();
            return _mapper.Map<List<JobTypeDTO>>(jobType);
        }

        public async Task<List<JobTypeDTO>> GetJobTypes()
        {
            var jobType = await _jobTypeDal.GetJobTypes();
            var jobtypeDto = _mapper.Map<List<JobTypeDTO>>(jobType);
            return jobtypeDto;
        }

        public async Task<JobTypeDTO> GetById(Guid id)
        {
            var jobType = await _jobTypeDal.GetById(id);
            var jobTypeDto = _mapper.Map<JobTypeDTO>(jobType);
            return jobTypeDto;
        }

        public async Task<bool> Update(JobTypeDTO JobTypeDTO)
        {
            var jobType = _mapper.Map<JobType>(JobTypeDTO);
            return await _jobTypeDal.UpdateJobType(jobType);
        }
    }
}
