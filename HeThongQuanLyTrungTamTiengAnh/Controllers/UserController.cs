using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeThongQuanLyTrungTamTiengAnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUserAsync()
        {
            try
            {
                var user = await _userService.GetAllUserAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all users."); // lỗi xảy ra khi nhận đc tất cả người dùng
                return StatusCode(500, "Internal server error"); // lỗi máy chủ       
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound($"User with ID {id} not NotFound"); // lỗi tìm ko thấy id
                }
                return Ok(user);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting user with ID {UserId}", id); // Đã xảy ra lỗi khi nhận được người dùng với id
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCreateDto userCreateDto)
        {
            if (!ModelState.IsValid) // Kiểm tra dữ liệu từ client gửi đến có hợp lệ không 
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createUser = await _userService.CreateUserAsync(userCreateDto);
                return CreatedAtAction(nameof(GetUserByIdAsync), new { id = createUser.UserId }, createUser);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user."); //Lỗi xảy ra trong khi tạo người dùng
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userUpdate = await _userService.UpdateUserAsync(userUpdateDto);
                if (userUpdate == null)
                {
                    return NotFound($"User with ID {id} not found");
                }
                return Ok(userUpdate);
            }
            catch (ApplicationException ex)
            {
                _logger.LogError(ex, "Business logic error while updating user with ID {UserId}.", id); // Lỗi logic trong khi cập nhật người dùng với ID
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user with ID {UserId}.", id); // Lỗi trong khi cập nhật người dùng với id
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            try
            {
                var userdelete = await _userService.DeleteUserAsync(id);
                if(userdelete == null)
                {
                    return NotFound($"User with ID {id} not found");
                }
                return NoContent();
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting user with ID {UserId}", id); // Xảy ra lỗi trong khi xóa người dùng bằng ID 
                return StatusCode(500, "Internal server error.");
            }
        }

    }
}
