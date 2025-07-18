using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IStudentRepository
    {
        Task<Students> GetStudentByIdAsync(int id);
        Task<IEnumerable<Students>> GetAllStudentAsync();
        Task<int> AddStudentAsync(Students students);
        Task<int> UpdateStudentAsync(Students students);
        Task<int> DeleteStudentAsync(int id);
    }
}
