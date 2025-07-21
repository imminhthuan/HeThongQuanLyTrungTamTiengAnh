using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace HeThongQuanLyTrungTamTiengAnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger _logger;

        public StudentController(IStudentService studentService, ILogger logger)
        {
            _studentService = studentService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudentAsync()
        {
            try
            {
                var student = await _studentService.GetAllStudentAsync();
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all teacher.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                if(student == null)
                {
                    return NotFound($"Student with id {id} not found.");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting user with ID {UserId}", id);
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody] StudentCreateDto studentCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var studentCreate = await _studentService.CreateStudentAsync(studentCreateDto);
                return CreatedAtAction(nameof(GetStudentByIdAsync), new { id = studentCreate.StudentId }, studentCreate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating student.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAsync(int id, [FromBody] StudentUpdateDto studentUpdateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var studentUpdate = await _studentService.UpdateStudentAsync(studentUpdateDto);
                if(studentUpdate == null)
                {
                    return NotFound($"Student with id {id} not found.");
                }
                return Ok(studentUpdate);

            }
            catch(ApplicationException ex)
            {
                _logger.LogError(ex, "Business logic error while updating user with ID {Student}", id);
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user with ID {Student}", id);
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            try
            {
                var studentDelete = await _studentService.DeleteStudentAsync(id);
                if(studentDelete == null)
                {
                    return NotFound($"Student with id {id} not found.");    
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
