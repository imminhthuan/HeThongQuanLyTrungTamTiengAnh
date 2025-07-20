using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IStudentClassesRepository
    {
        Task<StudentClasses> GetStudentClassesByIdAsync(int id);
        Task<IEnumerable<StudentClasses>> GetAllStudentCalssesAsync();
        Task<StudentClasses> AddStudentClassesAsync(StudentClasses studentClasses);
        Task<bool> UpdateStudentClassesAsync(StudentClasses studentClasses);
        Task<bool> DeleteStudentClassesAsync(int id);
    }
}
