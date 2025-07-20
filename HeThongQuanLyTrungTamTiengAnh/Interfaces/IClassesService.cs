using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IClassesService
    {
        Task<ClassesResponseDto> GetClassesByIdAsync(int id);
        Task<IEnumerable<ClassesResponseDto>> GetAllClassesAsync();
        Task<ClassesResponseDto> CreateClassesAsync(ClassesCreateDto classesCreateDto);
        Task<bool> UpdateClassesAsync(ClassesUpdateDto classesUpdateDto);
        Task<bool> DeleteClassesAsync(int id);
    }
}
