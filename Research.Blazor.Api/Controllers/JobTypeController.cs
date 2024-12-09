using Microsoft.AspNetCore.Mvc;
using Research.Application.Abstract;
using Research.Application.Contract;
using Research.Dto.DTO;
using Research.Entity.Models;

namespace Research.Blazor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobTypeController : ControllerBase
    {
        private readonly IJobTypeService _jobTypeService;

        public JobTypeController(IJobTypeService jobTypeService)
        {
            _jobTypeService = jobTypeService;
        }


        [HttpPost("CreateJobType")]
        public async Task<IActionResult> CreateJobType([FromBody] JobTypeDTO JobTypeDTO)
        {
            try
            {
                var jobType = await _jobTypeService.Create(JobTypeDTO);
                return Ok(jobType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating Job Type :{ex.Message}");
            }
        }

        [HttpGet("GetAllJobTypes")]
        public async Task<IActionResult> GetAllJobTypes()
        {
            try
            {
                var result = await _jobTypeService.GetAll();
                return Ok(result);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, $"Error getting Job Types : {ex.Message}");
            }
        }    
        
        [HttpGet("GetJobTypes")]
        public async Task<IActionResult> GetJobTypes()
        {
            try
            {
                var result = await _jobTypeService.GetJobTypes();
                return Ok(result);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, $"Error getting Job Types : {ex.Message}");
            }
        }



        [HttpPut("UpdateJobType")]
        public async Task<IActionResult> UpdateJobType(JobTypeDTO JobTypeDTO)
        {
            try
            {
                var result = await _jobTypeService.Update(JobTypeDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating Job Type : {ex.Message}");
            }
        }

        [HttpDelete("DeleteJobType/{id}")]
        public async Task<IActionResult> DeleteJobType(Guid id)
        {
            try
            {
                var result = await _jobTypeService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting Job Type : {ex.Message}");
            }
        }


        [HttpGet("GetJobTypeById/{id}")]
        public async Task<IActionResult> GetJobTypeById(Guid id)
        {
            try
            {
                var result = await _jobTypeService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting Job Type By Id : {ex.Message}");
            }
        }


    }
}
