using Microsoft.EntityFrameworkCore;
using Research.Entity.Models;
using Research.Infrastructure.Context;
using Research.Infrastructure.DA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Infrastructure.DA.Concrete
{
    public class JobTypeDal : GenericDal<JobType>, IJobTypeDal
    {
        private readonly ResearchDbContext _researchDbContext;
        public JobTypeDal(ResearchDbContext context) : base(context)
        {
            _researchDbContext = context;
        }

        public async Task<bool> CreateJobType(JobType JobType)
        {
            var flowId = await _researchDbContext.APPLICANT_FLOWs
                .Where(x => x.DEPARTMENT_ID == JobType.DEPARTMENT_ID)
                .Select(x => x.ID)
                .FirstOrDefaultAsync();

            var jobType = new JobType
            {
                ID = JobType.ID,
                DESC = JobType.DESC,
                DEPARTMENT_ID = JobType.DEPARTMENT_ID,
                FLOW_ID = flowId
            };

            await _researchDbContext.JOBTYPEs.AddAsync(jobType);
            var  result = await _researchDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<JobType>> GetJobTypes()
        {
            var response = await _researchDbContext.JOBTYPEs
                .Select(x => new JobType
                {
                    ID = x.ID,
                    DESC = x.DESC,
                    DEPARTMENT_ID = x.DEPARTMENT_ID,
                    Department = new Department
                    {
                        NAME = x.Department.NAME
                    }
                }).AsNoTracking().ToListAsync(); 

            return response;
        }

        public async Task<bool> UpdateJobType(JobType JobType)
        {
            var jobType = await _researchDbContext.JOBTYPEs.FirstOrDefaultAsync(x => x.ID == JobType.ID);

            try
            {
                if (jobType != null)
                {
                    jobType.DESC = JobType.DESC;
                    jobType.DEPARTMENT_ID = JobType.DEPARTMENT_ID;
                }
                await _researchDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Güncelleme yapılırken bir hata oluştu ! {ex.Message}");
            }

            return true;
        }
    }
}
