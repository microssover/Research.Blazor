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
    public class ApplicantFlowDal : GenericDal<ApplicantFlow>, IApplicantFlowDal
    {
        private readonly ResearchDbContext _researchDbContext;
        public ApplicantFlowDal(ResearchDbContext context) : base(context)
        {
            _researchDbContext = context;
        }

        public async Task<bool> CreateFlow(ApplicantFlow ApplicantFlow)
        {

            var firstFlow = new ApplicantFlow
            {
                ID = ApplicantFlow.ID,
                NEXT_FLOW_ID = ApplicantFlow.NEXT_FLOW_ID,
                DEPARTMENT_ID = ApplicantFlow.DEPARTMENT_ID
            };

            await _researchDbContext.APPLICANT_FLOWs.AddAsync(firstFlow);
            var result = await _researchDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<ApplicantFlow>> GetFlows()
        {
            var response = await _researchDbContext.APPLICANT_FLOWs
                .Select(x => new ApplicantFlow
                {
                    ID = x.ID,
                    NAME = x.NAME,
                    NEXT_FLOW_ID = x.NEXT_FLOW_ID,
                    DEPARTMENT_ID = x.DEPARTMENT_ID,
                    Department = new Department
                    {
                        NAME = x.Department.NAME,
                    }
                }).AsNoTracking().ToListAsync();
            return response;
        }

        public async Task<bool> UpdateFlow(ApplicantFlow ApplicantFlow)
        {
            var flow = await _researchDbContext.APPLICANT_FLOWs.FirstOrDefaultAsync(x => x.ID == ApplicantFlow.ID);
                

            try
            {
                if (flow != null)
                {
                    flow.NAME = ApplicantFlow.NAME;
                    flow.DEPARTMENT_ID = ApplicantFlow.DEPARTMENT_ID;
                    flow.NEXT_FLOW_ID = ApplicantFlow.NEXT_FLOW_ID;
                }
                await _researchDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Güncelleme sırasında bir hata oluştu ! {ex.Message}");
            }
            return true;

        }
    }
}
