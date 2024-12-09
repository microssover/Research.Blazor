using Research.Dto.DTO;

namespace Research.Application.Abstract
{
    public interface IApplicantRecordsService
    {
        Task<bool> Create(ApplicantRecordsDTO ApplicantRecordsDTO);
        Task<bool> Update(ApplicantRecordsDTO ApplicantRecordsDTO);
        Task<bool> Delete(Guid id);
        Task<List<ApplicantRecordsDTO>> GetAll(Guid managerId);
        Task<List<ApplicantRecordsDTO>> GetApprovedAndRejected();
        Task<List<ApplicantRecordsDTO>> GetApprovedApplicants();
        Task<ApplicantRecordsDTO> GetById(Guid id);
        Task<bool> Reject(ApplicantRecordsDTO ApplicantRecordsDTO);



    }
}
