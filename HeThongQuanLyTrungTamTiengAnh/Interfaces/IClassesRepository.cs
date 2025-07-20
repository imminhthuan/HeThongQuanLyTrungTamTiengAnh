using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IClassesRepository
    {
        Task<Classes> GetClassesByIdAsync(int id);
        Task<IEnumerable<Classes>> GetAllClassesAsync();
        Task<Classes> AddClassesAsync(Classes classes);
        Task<bool> UpdateClassesAsync(Classes classes);
        Task<bool> DeleteClassesAsync(int id);
    }
}
