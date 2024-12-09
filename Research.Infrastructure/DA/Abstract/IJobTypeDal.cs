using Research.Dto.DTO;
using Research.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Infrastructure.DA.Abstract
{
    public interface IJobTypeDal : IGenericDal<JobType>
    {
        Task<bool> CreateJobType(JobType JobType);
        Task<List<JobType>> GetJobTypes();
        Task<bool> UpdateJobType(JobType JobType);
    }
}
