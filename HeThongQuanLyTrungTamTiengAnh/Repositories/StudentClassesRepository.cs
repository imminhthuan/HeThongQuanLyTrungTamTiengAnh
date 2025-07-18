using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HeThongQuanLyTrungTamTiengAnh.Repositories
{
    public class StudentClassesRepository : IStudentClassesRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentClassesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentClasses> GetStudentClassesByIdAsync(int id)
        {
            return await _context.StudentClasse.FindAsync(id);
        }

        public async Task<IEnumerable<StudentClasses>> GetAllStudentCalssesAsync()
        {
            return await _context.StudentClasse.ToListAsync();
        }

        public async Task<int> AddStudentClassesAsync(StudentClasses studentClasses)
        {
            _context.StudentClasse.Add(studentClasses);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateStudentClassesAsync(StudentClasses studentClasses)
        {
            _context.StudentClasse.Update(studentClasses);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteStudentClassesAsync(int id)
        {
            var studentclasses = await _context.StudentClasse.FindAsync(id);
            if(studentclasses == null)
            {
                return 0;
            }
            _context.StudentClasse.Remove(studentclasses);
            return await _context.SaveChangesAsync();
        }
    }
}
