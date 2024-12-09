using Microsoft.EntityFrameworkCore;
using Research.Common.Enums;
using Research.Dto.DTO;
using Research.Entity.Models;
using Research.Infrastructure.Context;
using Research.Infrastructure.DA.Abstract;

namespace Research.Infrastructure.DA.Concrete
{
    public class ApplicantRecordsDal : GenericDal<ApplicantRecords>, IApplicantRecordsDal
    {
        private readonly ResearchDbContext _researchDbContext;
        public ApplicantRecordsDal(ResearchDbContext context) : base(context)
        {
            _researchDbContext = context;
        }

        public async Task<bool> CreateApplicant(ApplicantRecords ApplicantRecords)
        {
            var flowId = await _researchDbContext.JOBTYPEs.Where(x => x.ID == ApplicantRecords.JobTypeID)
         .Select(x => x.FLOW_ID)
         .FirstOrDefaultAsync();

            var newApplicant = new ApplicantRecords
            {
                ID = ApplicantRecords.ID,
                NAME = ApplicantRecords.NAME,
                SURNAME = ApplicantRecords.SURNAME,
                EMAIL = ApplicantRecords.EMAIL,
                JOB_TYPE = ApplicantRecords.JOB_TYPE,
                Status = ApplicantRecords.Status,
                APPLICANT_DATE = ApplicantRecords.APPLICANT_DATE,
                PROFILE_IMAGE = ApplicantRecords.PROFILE_IMAGE,
                JobTypeID = ApplicantRecords.JobTypeID,
                CURRENT_FLOW_ID = flowId,
            };
            await _researchDbContext.APPLICANT_RECORDSs.AddAsync(newApplicant);
            var result = await _researchDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<ApplicantRecords>> GetListForApplicantGrid(Guid managerId)
        {
            var records = await _researchDbContext.APPLICANT_RECORDSs.Where(x => x.Applicant_Flow.Department.MANAGER_ID == managerId)
                .Select(x => new ApplicantRecords
                {
                    ID = x.ID,
                    NAME = x.NAME,
                    SURNAME = x.SURNAME,
                    EMAIL = x.EMAIL,
                    JOB_TYPE = x.JOB_TYPE,
                    Status = x.Status,
                    APPLICANT_DATE = x.APPLICANT_DATE,
                    PROFILE_IMAGE = x.PROFILE_IMAGE,
                    CURRENT_FLOW_ID = x.CURRENT_FLOW_ID,
                    JobTypeID = x.JobTypeID

                }).ToListAsync();

            return records;
        }



        public async Task<bool> UpdateApplicantForApprovement(ApplicantRecords ApplicantRecords)
        {
            var response = await _researchDbContext.APPLICANT_RECORDSs
                .Where(x => x.ID == ApplicantRecords.ID)
                .Select(x => new ApplicantRecords
                {
                    ID = x.ID,
                    NAME = x.NAME,
                    SURNAME = x.SURNAME,
                    EMAIL = x.EMAIL,
                    JOB_TYPE = x.JOB_TYPE,
                    Status = x.Status,
                    APPLICANT_DATE = x.APPLICANT_DATE,
                    PROFILE_IMAGE = x.PROFILE_IMAGE,
                    CURRENT_FLOW_ID = x.CURRENT_FLOW_ID,
                    JobTypeID = x.JobTypeID,
                    Applicant_Flow = new ApplicantFlow
                    {
                        NEXT_FLOW_ID = x.Applicant_Flow.NEXT_FLOW_ID
                    }
                })
                .FirstOrDefaultAsync();

            if (response != null)
            {
                try
                {
                    response.CURRENT_FLOW_ID = response.Applicant_Flow.NEXT_FLOW_ID;
                    if (response.CURRENT_FLOW_ID != null)
                    {
                        response.Status = Common.Enums.ApplicantRecordFlow.Ongoing;
                    }
                    else if (response.CURRENT_FLOW_ID == null)
                    {
                        response.Status = Common.Enums.ApplicantRecordFlow.Approved;
                    }
                
                    _researchDbContext.Entry(response).State = EntityState.Modified;
                    await _researchDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Güncelleme işlemi sırasında bir hata oluştu ! : {ex.Message}");
                }
            }
            return true;
        }

        public async Task<bool> RejectApplicantOnApprovement(ApplicantRecords ApplicantRecords)
        {
            var response = await _researchDbContext.APPLICANT_RECORDSs
                .Where(x => x.ID == ApplicantRecords.ID)
                .Select(r => new ApplicantRecords
                {
                    ID = r.ID,
                    NAME = r.NAME,
                    SURNAME = r.SURNAME,
                    EMAIL = r.EMAIL,
                    JOB_TYPE = r.JOB_TYPE,
                    Status = r.Status,
                    PROFILE_IMAGE = r.PROFILE_IMAGE,
                    APPLICANT_DATE = r.APPLICANT_DATE,
                })
                .FirstOrDefaultAsync();

            if (response != null)
            {
                try
                {
                    response.Status = Common.Enums.ApplicantRecordFlow.Rejected;
                    response.CURRENT_FLOW_ID = null;

                    _researchDbContext.Entry(response).State = EntityState.Modified;
                    await _researchDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Reddetme işlemi sırasında bir hata oluştu ! : {ex.Message}");
                }
            }

            return true;
        }

        public async Task<List<ApplicantRecords>> GetListForApplicantStatus()
        {
            var response = await _researchDbContext.APPLICANT_RECORDSs
                .Where(x => x.Status == ApplicantRecordFlow.Rejected || x.Status == ApplicantRecordFlow.Approved)
                .Select(x => new ApplicantRecords
                {
                    NAME = x.NAME,
                    SURNAME = x.SURNAME,
                    EMAIL = x.EMAIL,
                    JOB_TYPE = x.JOB_TYPE,
                    Status = x.Status,
                    APPLICANT_DATE = x.APPLICANT_DATE,
                    ID = x.ID
                }).AsNoTracking().ToListAsync();

            return response;
        }

        public async Task<List<ApplicantRecords>> GetListForApplicantApproved()
        {
            var response = await _researchDbContext.APPLICANT_RECORDSs
                .Where(x => x.Status == ApplicantRecordFlow.Approved)
                .Select(x => new ApplicantRecords
                {
                    ID = x.ID,
                    NAME = x.NAME,
                    SURNAME = x.SURNAME,
                    EMAIL = x.EMAIL,
                    JOB_TYPE = x.JOB_TYPE,
                    Status = x.Status,
                    APPLICANT_DATE = x.APPLICANT_DATE,
                }).AsNoTracking().ToListAsync();

            return response;
        }
    }
}
