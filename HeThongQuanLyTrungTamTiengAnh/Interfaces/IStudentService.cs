using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResponseDto> GetStudentByIdAsync(int id);
        Task<IEnumerable<StudentResponseDto>> GetAllStudentAsync();
        Task<StudentResponseDto> CreateStudentAsync(StudentCreateDto studentCreateDto);
        Task<bool> UpdateStudentAsync(StudentUpdateDto studentUpdateDto);
        Task<bool> DeleteStudentAsync(int id);
    }
}
