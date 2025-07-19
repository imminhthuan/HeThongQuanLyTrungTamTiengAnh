using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTrungTamTiengAnh.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendance.FindAsync(id);
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendanceAsync()
        {
            return await _context.Attendance.ToListAsync();
        }

        public async Task<int> AddAttendanceAsync(Attendance attendance)
        {
            _context.Attendance.Add(attendance);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAttendanceAsync(Attendance attendance)
        {
            _context.Attendance.Update(attendance);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAttendanceAsync(int id)
        {
            var attendance = await _context.Attendance.FindAsync(id);
            if (attendance == null)
            {
                return 0;
            }
            _context.Attendance.Remove(attendance);
            return await _context.SaveChangesAsync();
        }
    }
}
