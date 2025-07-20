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

        public async Task<Courses> AddCourseAsync(Courses courses)
        {
            _context.Course.Add(courses);
            await _context.SaveChangesAsync();
            return courses;
        }

        public async Task<bool> UpdateCourseAsync(Courses courses)
        {
            _context.Course.Update(courses);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if(course == null)
            {
                return false;
            }
            _context.Course.Remove(course);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
