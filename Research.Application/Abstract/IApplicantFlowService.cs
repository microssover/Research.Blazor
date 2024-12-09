using Research.Dto.DTO;

namespace Research.Application.Abstract
{
    public interface IApplicantFlowService
    {
        Task<bool> Create(ApplicantFlowDTO Applicant_FlowDTO);
        Task<bool> Update(ApplicantFlowDTO Applicant_FlowDTO);
        Task<bool> Delete(Guid id);
        Task<ApplicantFlowDTO> GetById(Guid id);
        Task<List<ApplicantFlowDTO>> GetAll();
        Task<List<ApplicantFlowDTO>> GetFlows();

    }
}
