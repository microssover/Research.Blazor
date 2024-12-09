using Research.Dto.DTO;

namespace Research.Blazor.UI.Services.Abstract
{
    public interface IApplicantImagesService
    {
        Task<bool> Create(ApplicantImagesDTO ApplicantImagesDTO);
        Task<bool> Update(ApplicantImagesDTO ApplicantImagesDTO);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<ApplicantImagesDTO>?> GetAll();
        Task<IEnumerable<ApplicantImagesDTO>?> GetImageById(Guid applicantId);
    }
}
