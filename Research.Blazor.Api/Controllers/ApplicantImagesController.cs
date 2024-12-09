using Microsoft.AspNetCore.Mvc;
using Research.Application.Abstract;

namespace Research.Blazor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantImagesController : ControllerBase
    {
        private readonly IApplicantImagesService _applicantImagesService;

        public ApplicantImagesController(IApplicantImagesService applicantImagesService)
        {
            _applicantImagesService = applicantImagesService;
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
                return StatusCode(500, $"An error occured while getting Images : {ex.Message}");
            }

        }

        [HttpGet("GetImageById")]
        public async Task<IActionResult> GetImageById(Guid applicantId)
        {
            try
            {
                var result = await _applicantImagesService.GetImageById(applicantId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while getting Images : {ex.Message}");
            }

        }
    }
}
