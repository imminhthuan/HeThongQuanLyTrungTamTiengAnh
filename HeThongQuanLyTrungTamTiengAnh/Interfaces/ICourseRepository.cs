using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface ICourseRepository
    {
        Task<Courses> GetCourseByIdAsync(int id);
        Task<IEnumerable<Courses>> GetAllCourseAsync();
        Task<Courses> AddCourseAsync(Courses courses);
        Task<bool> UpdateCourseAsync(Courses courses);
        Task<bool> DeleteCourseAsync(int id);
    }
}
