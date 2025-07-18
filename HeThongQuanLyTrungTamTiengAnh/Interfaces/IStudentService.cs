using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IStudentService
    {
        Task<Students> GetStudentByIdAsync(int id);
        Task<IEnumerable<Students>> GetAllStudentAsync();
        Task<Students> CreateStudentAsync(Students students);
        Task UpdateStudentAsync(Students students);
        Task DeleteStudentAsync(int id);
    }
}
