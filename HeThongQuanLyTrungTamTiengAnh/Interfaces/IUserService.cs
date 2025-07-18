using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IUserService
    {
        Task<Users> GetUserByIdAsync(int id);
        Task<IEnumerable<Users>> GetAllUserAsync();
        Task<bool> CreateUserAsync(Users users);
        Task<bool> UpdateUserAsync(Users users);
        Task<bool> DeleteUserAsync(int id);
    }
}
