using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> GetUserByIdAsync(int id);
        Task<IEnumerable<Users>> GetAllUserAsync();
        Task<int> AddUserAsync(Users users);
        Task<int> UpdateUserAsync(Users users);
        Task<int> DeleteUserAsync(int id);
    }
}
