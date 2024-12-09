using Microsoft.AspNetCore.Http;
using Research.Dto.DTO;

namespace Research.Application.Abstract
{
    public interface IApplicantImagesService 
    {
        Task<bool> CreateImages(IFormFile file);
        Task<bool> Update(ApplicantImagesDTO ApplicantImagesDTO);
        Task<bool> Delete(Guid id);
        Task<List<ApplicantImagesDTO>> GetAll();
        Task<List<ApplicantImagesDTO>> GetImageById(Guid applicantId);
    }
}
