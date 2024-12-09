using Microsoft.AspNetCore.Mvc;
using Research.Application.Abstract;
using Research.Dto.DTO;

namespace Research.Blazor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost("CreateManager")]
        public async Task<IActionResult> CreateManager([FromBody] ManagerDTO ManagerDTO)
        {
            try
            {
                var result = await _managerService.Create(ManagerDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error saving manager : {ex.Message}");
            }
        }

        [HttpGet("GetAllManagers")]
        public async Task<IActionResult> GetAllManagers( )
        {
            try
            {
                var manager = await _managerService.GetAll();
                return Ok(manager);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting managers : {ex.Message}");
            }

        }

        [HttpGet("GetManagers")]
        public async Task<IActionResult> GetManagers()
        {
            try
            {
                var manager = await _managerService.GetManagers();
                return Ok(manager);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting managers : {ex.Message}");
            }

        }

        [HttpDelete("DeleteManager/{id}")]
        public async Task<IActionResult> DeleteManager(Guid id)
        {
            try
            {
                var result = await _managerService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting manager : {ex.Message}");
            }
        }

        [HttpPut("UpdateManager")]
        public async Task<IActionResult> UpdateManager(ManagerDTO ManagerDTO)
        {
            try
            {
                var updatedManager = await _managerService.Update(ManagerDTO);
                return Ok(updatedManager);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error updating manager : {ex.Message}");

            }
        }


    }
}
