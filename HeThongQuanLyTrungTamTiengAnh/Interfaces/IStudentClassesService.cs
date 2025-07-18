using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IStudentClassesService
    {
        Task<StudentClasses> GetStudentClassesByIdAsync(int id);
        Task<IEnumerable<StudentClasses>> GetAllStudentClassesAsync();
        Task<StudentClasses> CreateStudentClassesAsync(StudentClasses studentClasses);
        Task UpdateStudentClassesAsync(StudentClasses studentClasses);
        Task DeleteStudentClassesAsync(int id);
    }
}
