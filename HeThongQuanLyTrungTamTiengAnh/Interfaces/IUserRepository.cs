using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> GetUserByIdAsync(int id);
        Task<IEnumerable<Users>> GetAllUserAsync();
        Task<Users> GetUserByEmailAsync(string email);
        Task<Users> AddUserAsync(Users users);
        Task<bool> UpdateUserAsync(Users users);
        Task<bool> DeleteUserAsync(int id);
    }
}
