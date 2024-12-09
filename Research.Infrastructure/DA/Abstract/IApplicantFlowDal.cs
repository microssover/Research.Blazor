using Research.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Infrastructure.DA.Abstract
{
    public interface IApplicantFlowDal : IGenericDal<ApplicantFlow>
    {
        Task<bool> CreateFlow(ApplicantFlow ApplicantFlow);
        Task<bool> UpdateFlow(ApplicantFlow ApplicantFlow);
        Task<List<ApplicantFlow>> GetFlows();
    }
}
