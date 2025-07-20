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

        public async Task<StudentClasses> AddStudentClassesAsync(StudentClasses studentClasses)
        {
            _context.StudentClasse.Add(studentClasses);
            await _context.SaveChangesAsync();
            return studentClasses;
        }

        public async Task<bool> UpdateStudentClassesAsync(StudentClasses studentClasses)
        {
            _context.StudentClasse.Update(studentClasses);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteStudentClassesAsync(int id)
        {
            var studentclasses = await _context.StudentClasse.FindAsync(id);
            if(studentclasses == null)
            {
                return false;
            }
            _context.StudentClasse.Remove(studentclasses);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
