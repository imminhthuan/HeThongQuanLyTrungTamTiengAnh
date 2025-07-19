using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserResponseDto>> GetAllUserAsync();
        Task<UserResponseDto> CreateUserAsync(UserCreateDto userCreateDto);
        Task<bool> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
