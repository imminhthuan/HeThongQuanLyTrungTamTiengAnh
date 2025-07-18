using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface ITeacherRepository
    {
        Task<Teachers> GetTeacherByIdAsync(int id);
        Task<IEnumerable<Teachers>> GetAllTeacherAsync();
        Task<int> AddTeacherAsync(Teachers teachers);
        Task<int> UpdateTeacherAsync(Teachers teachers);
        Task<int> DeleteTeacherAsync(int id);
    }
}
