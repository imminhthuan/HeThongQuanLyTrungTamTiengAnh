using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface ITeacherRepository
    {
        Task<Teachers> GetTeacherByIdAsync(int id);
        Task<IEnumerable<Teachers>> GetAllTeacherAsync();
        Task<Teachers> GetTeacherEmailAsync(string email);
        Task<Teachers> AddTeacherAsync(Teachers teachers);
        Task<bool> UpdateTeacherAsync(Teachers teachers);
        Task<bool> DeleteTeacherAsync(int id);
    }
}
