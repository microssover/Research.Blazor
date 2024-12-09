using AutoMapper;
using Microsoft.AspNetCore.Http;
using Research.Application.Abstract;
using Research.Dto.DTO;
using Research.Entity.Models;
using Research.Infrastructure.DA.Abstract;

namespace Research.Application.Contract
{
    public class ApplicantImagesService : IApplicantImagesService
    {
        private readonly IApplicantImagesDal _applicantImagesDal;
        private readonly IMapper _mapper;
        public ApplicantImagesService(IApplicantImagesDal applicantImagesDal, IMapper mapper)
        {
            _applicantImagesDal = applicantImagesDal;
            _mapper = mapper;
        }

        public async Task<bool> CreateImages(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    throw new ArgumentException("No file was uploaded.");
                }

                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var applicantImageDto = new ApplicantImagesDTO
                {
                    Path = "/uploads/" + uniqueFileName
                };

                return await _applicantImagesDal.CreateImage(_mapper.Map<ApplicantImages>(applicantImageDto));
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Delete(Guid id)
        {
            return await _applicantImagesDal.Delete(id);
        }
        public async Task<List<ApplicantImagesDTO>> GetAll()
        {
            var applicantFlow = await _applicantImagesDal.GetAll();
            return _mapper.Map<List<ApplicantImagesDTO>>(applicantFlow);
        }

        public async Task<List<ApplicantImagesDTO>> GetImageById(Guid applicantId)
        {
            var applicantImage = await _applicantImagesDal.GetImageById(applicantId);
            return _mapper.Map<List<ApplicantImagesDTO>>(applicantImage);
        }

        public async Task<bool> Update(ApplicantImagesDTO ApplicantImagesDTO)
        {
            var applicantImage = _mapper.Map<ApplicantImages>(ApplicantImagesDTO);
            return await _applicantImagesDal.Update(applicantImage);
        }
    }
}
