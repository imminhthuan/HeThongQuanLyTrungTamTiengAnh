using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> GetUserByIdAsync(int id);
        Task<IEnumerable<Users>> GetAllUserAsync();
        Task<bool> AddUserAsync(Users users);
        Task<bool> UpdateUserAsync(Users users);
        Task<bool> DeleteUserAsync(int id);
    }
}
