using Microsoft.AspNetCore.Mvc;
using Research.Application.Abstract;
using Research.Application.Contract;
using Research.Dto.DTO;
using Research.Entity.Models;
using Research.Infrastructure.Context;

namespace Research.Mvc.Controllers
{
    [Route("ApplicantImages")]
    public class ApplicantImagesController : Controller
    {
        private readonly IApplicantImagesService _applicantImagesService;

        public ApplicantImagesController(IApplicantImagesService applicantImagesService)
        {
            _applicantImagesService = applicantImagesService;
        }
        public IActionResult ApplicantImage()
        {
            return View();
        }

        [HttpPost("CreateApplicantImage")]
        public async Task<IActionResult> CreateApplicantImage([FromForm] IFormFile file)
        {
            try
            {
                var isSaved = await _applicantImagesService.CreateImages(file);

                if (isSaved)
                {
                    return Ok(new { message = "File uploaded and path saved successfully!" });
                }

                return StatusCode(500, "Error saving the file path in the database.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating Applicant Image :{ex.Message}");
            }

        }


        [HttpGet("GetAllApplicantImages")]
        public async Task<IActionResult> GetAllApplicantImages()
        {
            try
            {
                var result = await _applicantImagesService.GetAll();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting Applicant Images :{ex.Message}");
            }

        }

        [HttpPut("UpdateApplicantImage")]
        public async Task<IActionResult> UpdateApplicantImage(ApplicantImagesDTO ApplicantImagesDTO)
        {
            try
            {
                var result = await _applicantImagesService.Update(ApplicantImagesDTO);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating Applicant Image :{ex.Message}");
            }

        }

        [HttpGet("GetImageById")]
        public async Task<IActionResult> GetApplicantImageById(Guid applicantId)
        {
            try
            {
                var result = await _applicantImagesService.GetImageById(applicantId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting Applicant Image By Id :{ex.Message}");
            }

        }

        [HttpDelete("DeleteApplicantImage/{id}")]
        public async Task<IActionResult> DeleteApplicantImage(Guid id)
        {
            try
            {
                var result = await _applicantImagesService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting Applicant Image :{ex.Message}");
            }
        }
    }
}
