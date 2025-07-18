using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface ICourseService
    {
        Task<Courses> GetCourseByIdAsync(int id);
        Task<IEnumerable<Courses>> GetAllCourseAsync();
        Task<Courses> CreateCourseAsync(Courses courses);
        Task UpdateCourseAsync(Courses course);
        Task DeleteCourseAsync(int id);
    }
}
