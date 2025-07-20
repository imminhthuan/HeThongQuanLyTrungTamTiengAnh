using HeThongQuanLyTrungTamTiengAnh.DTOs;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IStudentClassesService
    {
        Task<StudentClassesResponseDto> GetStudentClassesByIdAsync(int id);
        Task<IEnumerable<StudentClassesResponseDto>> GetAllStudentClassesAsync();
        Task<StudentClassesResponseDto> CreateStudentClassesAsync(StudentClassesCreateDto studentClassesCreateDto);
        Task<bool> UpdateStudentClassesAsync(StudentClassesUpdateDto studentClassesUpdateDto);
        Task<bool> DeleteStudentClassesAsync(int id);
    }
}
