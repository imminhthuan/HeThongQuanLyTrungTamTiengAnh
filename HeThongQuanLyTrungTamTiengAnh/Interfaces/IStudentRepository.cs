using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IStudentRepository
    {
        Task<Students> GetStudentByIdAsync(int id);
        Task<IEnumerable<Students>> GetAllStudentAsync();
        Task<Students> GetStudentEmailAsync(string email);
        Task<Students> AddStudentAsync(Students students);
        Task<bool> UpdateStudentAsync(Students students);
        Task<bool> DeleteStudentAsync(int id);
    }
}
