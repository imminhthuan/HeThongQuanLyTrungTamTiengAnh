using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface ICourseService
    {
        Task<CourseResponseDto> GetCourseByIdAsync(int id);
        Task<IEnumerable<CourseResponseDto>> GetAllCourseAsync();
        Task<CourseResponseDto> CreateCourseAsync(CourseCreateDto courseCreateDto);
        Task<bool> UpdateCourseAsync(CourseUpdateDto courseUpdateDto);
        Task<bool> DeleteCourseAsync(int id);
    }
}
