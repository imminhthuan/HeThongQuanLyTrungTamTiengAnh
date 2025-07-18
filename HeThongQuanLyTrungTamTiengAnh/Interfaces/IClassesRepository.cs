using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IClassesRepository
    {
        Task<Classes> GetClassesByIdAsync(int id);
        Task<IEnumerable<Classes>> GetAllClassesAsync();
        Task AddClassesAsync(Classes classes);
        Task UpdateClassesAsync(Classes classes);
        Task DeleteClassesAsync(int id);
    }
}
