using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IClassesRepository
    {
        Task<Classes> GetClassesByIdAsync(int id);
        Task<IEnumerable<Classes>> GetAllClassesAsync();
        Task<int> AddClassesAsync(Classes classes);
        Task<int> UpdateClassesAsync(Classes classes);
        Task<int> DeleteClassesAsync(int id);
    }
}
