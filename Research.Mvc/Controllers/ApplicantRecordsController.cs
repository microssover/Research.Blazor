using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Research.Application.Abstract;
using Research.Dto.DTO;
using Research.Infrastructure.Context;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Research.Mvc.Controllers
{
    [Route("ApplicantRecords")]
    public class ApplicantRecordsController : Controller
    {
        private readonly IApplicantRecordsService _applicantRecordsService;
        private readonly IJobTypeService _jobTypeService;
        private readonly ResearchDbContext _researchDbContext;

        public ApplicantRecordsController(IApplicantRecordsService applicantRecordsService, ResearchDbContext researchDbContext, IJobTypeService jobTypeService)
        {
            _applicantRecordsService = applicantRecordsService;
            _researchDbContext = researchDbContext;
            _jobTypeService = jobTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var jobTypes = await _jobTypeService.GetAll();
                return View(jobTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching job types: {ex.Message}");
            }
        }

        [HttpPost("CreateApplicant")]
        public async Task<IActionResult> CreateApplicant([FromBody] ApplicantRecordsDTO ApplicantRecordsDTO)
        {
            try
            {
                var result = await _applicantRecordsService.Create(ApplicantRecordsDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating Applicant : {ex.Message}");
            }
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
        public async Task<IActionResult> UpdateApplicant(ApplicantRecordsDTO Applicant_RecordsDTO)
        {
            try
            {
                var result = await _applicantRecordsService.Update(Applicant_RecordsDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating Applicant : {ex.Message}");
            }
        }


        [HttpGet("GetApplicantById")]
        public async Task<IActionResult> GetApplicantById(Guid id)
        {
            try
            {
                var result = await _applicantRecordsService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting Applicant : {ex.Message}");
            }
        }

        //[HttpDelete("DeleteApplicant")]
        //public async Task<IActionResult> DeleteApplicant(ApplicantRecordsDTO Applicant_RecordsDTO)
        //{
        //    try
        //    {
        //        var result = await _applicantRecordsService.Delete(Applicant_RecordsDTO);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error deleting Applicant : {ex.Message}");
        //    }
        //}
    }
}
