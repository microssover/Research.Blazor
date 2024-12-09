using Research.Common.Enums;
using Research.Dto.DTO;
using Research.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Infrastructure.DA.Abstract
{
    public interface IApplicantRecordsDal : IGenericDal<ApplicantRecords>
    {
        Task<List<ApplicantRecords>> GetListForApplicantGrid(Guid managerId);
        Task<List<ApplicantRecords>> GetListForApplicantStatus();
        Task<List<ApplicantRecords>> GetListForApplicantApproved();

        Task<bool> UpdateApplicantForApprovement(ApplicantRecords ApplicantRecords);

        Task<bool> CreateApplicant(ApplicantRecords ApplicantRecords);

        Task<bool> RejectApplicantOnApprovement(ApplicantRecords ApplicantRecords);
    }
}
