using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTrungTamTiengAnh.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Students> GetStudentByIdAsync(int id)
        {
            return await _context.Student.FindAsync(id);
        }

        public async Task<IEnumerable<Students>> GetAllStudentAsync()
        {
            return await _context.Student.ToListAsync();
        }

        public async Task<Students> GetStudentEmailAsync(string email)
        {
            return await _context.Student.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Students> AddStudentAsync(Students students)
        {
            _context.Student.Add(students);
            await _context.SaveChangesAsync();
            return students;
        }

        public async Task<bool> UpdateStudentAsync(Students students)
        {
            _context.Student.Update(students);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if(student == null)
            {
                return false;
            }
            _context.Student.Remove(student);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
