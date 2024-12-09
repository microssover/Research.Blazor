using Microsoft.AspNetCore.Mvc;
using Research.Application.Abstract;
using Research.Dto.DTO;

namespace Research.Blazor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(DepartmentDTO DepartmentDTO)
        {
            try
            {
                var result = await _departmentService.Create(DepartmentDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating department : {ex.Message}");

            }
        }

        [HttpGet("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var result = await _departmentService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting departments : {ex.Message}");

            }
        }  
        
        
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var result = await _departmentService.GetDepartments();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting departments : {ex.Message}");

            }
        }


        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(DepartmentDTO DepartmentDTO)
        {
            try
            {
                var result = await _departmentService.Update(DepartmentDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating department : {ex.Message}");

            }
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            try
            {
                var result = await _departmentService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting department : {ex.Message}");
            }
        }


        [HttpGet("GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            try
            {
                var result = await _departmentService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting department by Id : {ex.Message}");
            }
        }

    }
}
