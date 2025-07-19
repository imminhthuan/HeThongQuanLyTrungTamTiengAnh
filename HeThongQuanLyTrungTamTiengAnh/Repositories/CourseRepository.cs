using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace HeThongQuanLyTrungTamTiengAnh.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public  CourseRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Courses> GetCourseByIdAsync(int id)
        {
            return await _context.Course.FindAsync(id);
        }

        public async Task<IEnumerable<Courses>> GetAllCourseAsync()
        {
            return await _context.Course.ToListAsync();
        }

        public async Task<int> AddCourseAsync(Courses courses)
        {
            _context.Course.Add(courses);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCourseAsync(Courses courses)
        {
            _context.Course.Update(courses);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCourseAsync(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if(course == null)
            {
                return 0;
            }
            _context.Course.Remove(course);
            return await _context.SaveChangesAsync();
        }
    }
}
