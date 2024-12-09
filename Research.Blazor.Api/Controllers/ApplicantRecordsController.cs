using Microsoft.AspNetCore.Mvc;
using Research.Application.Abstract;
using Research.Dto.DTO;

namespace Research.Blazor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantRecordsController : ControllerBase
    {
        private readonly IApplicantRecordsService _applicantRecordsService;

        public ApplicantRecordsController(IApplicantRecordsService applicantRecordsService)
        {
            _applicantRecordsService = applicantRecordsService;
        }

        [HttpGet("GetAllApplicants")]
        public async Task<IActionResult> GetAllApplicants(Guid managerId)
        {
            try
            {
                var result = await _applicantRecordsService.GetAll(managerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting Applicants : {ex.Message}");
            }
        }

        [HttpPut("UpdateApplicant")]
        public async Task<IActionResult> UpdateApplicant(ApplicantRecordsDTO ApplicantRecordsDTO)
        {
            try
            {
                var result = await _applicantRecordsService.Update(ApplicantRecordsDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating Applicant : {ex.Message}");
            }
        }

        [HttpPut("RejectApplicant")]
        public async Task<IActionResult> RejectApplicant(ApplicantRecordsDTO ApplicantRecordsDTO)
        {
            try
            {
                var result = await _applicantRecordsService.Reject(ApplicantRecordsDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating Applicant : {ex.Message}");
            }
        }

        [HttpDelete("DeleteApplicant/{id}")]
        public async Task<IActionResult> DeleteApplicant(Guid id)
        {
            try
            {
                var result = await _applicantRecordsService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting Applicant : {ex.Message}");
            }
        }

        [HttpGet("GetApplicantByStatus")]
        public async Task<IActionResult> GetApplicantByStatus()
        {
            try
            {
                var result = await _applicantRecordsService.GetApprovedAndRejected();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting Applicant : {ex.Message}");
            }
        }

        [HttpGet("GetApprovedApplicants")]
        public async Task<IActionResult> GetApprovedApplicants()
        {
            try
            {
                var result = await _applicantRecordsService.GetApprovedApplicants();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error sending email : {ex.Message}");
            }
        }
    }
}
