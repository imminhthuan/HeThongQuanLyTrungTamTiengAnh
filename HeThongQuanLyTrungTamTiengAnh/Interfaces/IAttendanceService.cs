using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IAttendanceService
    {
        Task<AttendanceResponseDto> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<AttendanceResponseDto>> GetAllAttendanceAsync();
        Task<AttendanceResponseDto> CreateAttendanceAsync(AttendanceCreateDto attendanceCreateDto);
        Task<bool> UpdateAttendanceAsync(AttendanceUpdateDto attendanceUpdateDto);
        Task<bool> DeleteAttendanceAsync(int id);
    }
}
