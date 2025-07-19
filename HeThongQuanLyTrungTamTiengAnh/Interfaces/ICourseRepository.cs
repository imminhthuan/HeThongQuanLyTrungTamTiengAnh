using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface ICourseRepository
    {
        Task<Courses> GetCourseByIdAsync(int id);
        Task<IEnumerable<Courses>> GetAllCourseAsync();
        Task<int> AddCourseAsync(Courses courses);
        Task<int> UpdateCourseAsync(Courses courses);
        Task<int> DeleteCourseAsync(int id);
    }
}
