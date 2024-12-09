using Microsoft.AspNetCore.Mvc;
using Research.Application.Abstract;
using Research.Dto.DTO;

namespace Research.Blazor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantFlowController : ControllerBase
    {
        private readonly IApplicantFlowService _applicantFlowService;

        public ApplicantFlowController(IApplicantFlowService applicantFlowService)
        {
            _applicantFlowService = applicantFlowService;
        }

        [HttpPost("CreateApplicantFlow")]
        public async Task<IActionResult> CreateApplicantFlow(ApplicantFlowDTO ApplicantFlowDTO)
        {
            try
            {
                var result = await _applicantFlowService.Create(ApplicantFlowDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating Applicant Flow : {ex.Message}");

            }
        }

        [HttpGet("GetApplicantFlows")]
        public async Task<IActionResult> GetApplicantFlows()
        {
            try
            {
                var result = await _applicantFlowService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting Applicant Flows : {ex.Message}");
            }
        }
        [HttpGet("GetFlows")]
        public async Task<IActionResult> GetFlows()
        {
            try
            {
                var result = await _applicantFlowService.GetFlows();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting Applicant Flows : {ex.Message}");
            }
        }

        [HttpPut("UpdateApplicantFlow")]
        public async Task<IActionResult> UpdateApplicantFlow(ApplicantFlowDTO ApplicantFlowDTO)
        {
            try
            {
                var result = await _applicantFlowService.Update(ApplicantFlowDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating Applicant Flow : {ex.Message}");
            }
        }

        [HttpGet("GetApplicantFlowById")]
        public async Task<IActionResult> GetApplicantFlowById(Guid id)
        {
            try
            {
                var result = await _applicantFlowService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting Applicant Flow : {ex.Message}");
            }
        }

        [HttpDelete("DeleteApplicantFlow/{id}")]
        public async Task<IActionResult> DeleteApplicantFlow(Guid id)
        {
            try
            {
                var result = await _applicantFlowService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting Applicant Flow : {ex.Message}");
            }
        }
    }
}
