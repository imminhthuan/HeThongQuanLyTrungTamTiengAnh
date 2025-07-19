using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<Attendance>> GetAllAttendanceAsync();
        Task<int> AddAttendanceAsync(Attendance attendance);
        Task<int> UpdateAttendanceAsync(Attendance attendance);
        Task<int> DeleteAttendanceAsync(int id);
    }
}
