using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherResponseDto> GetTeacherByIdAsync(int id);
        Task<IEnumerable<TeacherResponseDto>> GetAllTeacherAsync();
        Task<TeacherResponseDto> CreateTeacherAsync(TeacherCreateDto teacherCreateDto);
        Task<bool> UpdateTeacherAsync(TeacherUpdateDto teacherUpdateDto);
        Task<bool> DeleteTeacherAsync(int id);
    }
}
