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

        public async Task<int> AddTeacherAsync(Teachers teachers)
        {
            _context.Teacher.Add(teachers);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateTeacherAsync(Teachers teachers)
        {
            _context.Teacher.Update(teachers);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if(teacher == null)
            {
                return 0;
            }
            _context.Teacher.Remove(teacher);
            return await _context.SaveChangesAsync();
        }
    }
}
