using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<Attendance>> GetAllAttendanceAsync();
        Task AddAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int id);
    }
}
