using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Migrations;
using HeThongQuanLyTrungTamTiengAnh.Model;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTrungTamTiengAnh.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Teachers> GetTeacherByIdAsync(int id)
        {
            return await _context.Teacher.FindAsync(id);
        }

        public async Task<IEnumerable<Teachers>> GetAllTeacherAsync()
        {
            return await _context.Teacher.ToListAsync();
        }

        public async Task<Teachers> GetTeacherEmailAsync(string email)
        {
            return await _context.Teacher.FirstOrDefaultAsync(t => t.Email == email);
        }

        public async Task<Teachers> AddTeacherAsync(Teachers teachers)
        {
            _context.Teacher.Add(teachers);
            await _context.SaveChangesAsync();
            return teachers;
        }

        public async Task<bool> UpdateTeacherAsync(Teachers teachers)
        {
            _context.Teacher.Update(teachers);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if(teacher == null)
            {
                return false;
            }
            _context.Teacher.Remove(teacher);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
