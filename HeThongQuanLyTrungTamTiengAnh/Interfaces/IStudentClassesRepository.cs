using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IStudentClassesRepository
    {
        Task<StudentClasses> GetStudentClassesByIdAsync(int id);
        Task<IEnumerable<StudentClasses>> GetAllStudentCalssesAsync();
        Task<int> AddStudentClassesAsync(StudentClasses studentClasses);
        Task<int> UpdateStudentClassesAsync(StudentClasses studentClasses);
        Task<int> DeleteStudentClassesAsync(int id);
    }
}
