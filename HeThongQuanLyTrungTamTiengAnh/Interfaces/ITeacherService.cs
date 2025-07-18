using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface ITeacherService
    {
        Task<Teachers> GetTeacherByIdAsync(int id);
        Task<IEnumerable<Teachers>> getAllTeacherAsync();
        Task<Teachers> CreateTeacherAsync(Teachers teachers);
        Task UpdateTeacherAsync(Teachers teachers);
        Task deleteTeacherAsync(int id);
    }
}
