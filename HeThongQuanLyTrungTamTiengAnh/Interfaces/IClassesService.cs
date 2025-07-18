using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IClassesService
    {
        Task<Classes> GetClassesByIdAsync(int id);
        Task<IEnumerable<Classes>> GetAllClassesAsync();
        Task<Classes> CreateClassesAsync(Classes classes);
        Task UpdateClassesAsync(Classes classes);
        Task DeleteClassesAsync(int id);
    }
}
