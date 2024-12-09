using Research.Dto.DTO;

namespace Research.Blazor.UI.Services.Abstract
{
    public interface IApplicantRecordsService
    {
        Task<bool> Create(ApplicantRecordsDTO ApplicantRecordsDTO);
        Task<bool> Update(ApplicantRecordsDTO ApplicantRecordsDTO);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<ApplicantRecordsDTO>?> GetAll(Guid managerId);
        Task<bool> Reject(ApplicantRecordsDTO ApplicantRecordsDTO);
        Task<ApplicantRecordsDTO?> GetById(Guid id);

        Task<IEnumerable<ApplicantRecordsDTO>?> GetApplicantByStatus();
        Task<IEnumerable<ApplicantRecordsDTO>?> GetApprovedApplicants();
    }
}
