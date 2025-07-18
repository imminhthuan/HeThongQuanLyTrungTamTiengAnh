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

        public async Task<int> AddStudentAsync(Students students)
        {
            _context.Student.Add(students);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateStudentAsync(Students students)
        {
            _context.Student.Update(students);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if(student == null)
            {
                return 0;
            }
            _context.Student.Remove(student);
            return await _context.SaveChangesAsync();
        }
    }
}
