using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface ICourseRepository
    {
        Task<Courses> GetCourseByIdAsync(int id);
        Task<IEnumerable<Courses>> GetAllCourseAsync();
        Task AddCourseAsync(Courses courses);
        Task UpdateCourseAsync(Courses courses);
        Task DeleteCoureAsync(int id);
    }
}
