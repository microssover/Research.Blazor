using Research.Dto.DTO;

namespace Research.Blazor.UI.Services.Abstract
{
    public interface IApplicantFlowService
    {
        public Task<bool> Create(ApplicantFlowDTO ApplicantFlowDTO);
        public Task<bool> Update(ApplicantFlowDTO ApplicantFlowDTO);
        public Task<bool> Delete(Guid id);
        public Task<ApplicantFlowDTO?> GetById(Guid id);
        public Task<IEnumerable<ApplicantFlowDTO>?> GetAll();
        public Task<IEnumerable<ApplicantFlowDTO>?> GetFlows();
    }
}
