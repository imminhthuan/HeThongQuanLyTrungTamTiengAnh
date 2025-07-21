using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HeThongQuanLyTrungTamTiengAnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly ILogger _logger;

        public TeacherController(ITeacherService teacherService, ILogger logger)
        {
            _teacherService = teacherService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTeacherAsync()
        {
            try
            {
                var teacher = await _teacherService.GetAllTeacherAsync();
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all teacher.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherByIdAsync(int id)
        {
            try
            {
                var teacher = await _teacherService.GetTeacherByIdAsync(id);
                if (teacher == null)
                {
                    return NotFound($"User with ID {id} not found");
                }
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting user with ID {UserId}", id);
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacherAsync([FromBody] TeacherCreateDto teacherCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createTeacher = await _teacherService.CreateTeacherAsync(teacherCreateDto);
                return CreatedAtAction(nameof(GetTeacherByIdAsync), new { id = createTeacher.TeacherId }, createTeacher);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating teacher.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacherAsync(int id, [FromBody] TeacherUpdateDto teacherUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var teacherUpdate = await _teacherService.UpdateTeacherAsync(teacherUpdateDto);
                if (teacherUpdate == null)
                {
                    return NotFound($"Teacher with Id {id} not found");
                }
                return Ok(teacherUpdate);
            }
            catch (ApplicationException ex)
            {
                _logger.LogError(ex, "Business logic error while updating user with ID {Teacher}", id);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user with ID {UserId}", id);
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherAsync(int id)
        {
            try
            {
                var teacherDelete = await _teacherService.DeleteTeacherAsync(id);
                if(teacherDelete == null)
                {
                    return NotFound($"Teacher with id {id} not found");
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting user with ID {UserId}", id);
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
