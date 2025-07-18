using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTrungTamTiengAnh.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<IEnumerable<Users>> GetAllUserAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<int> AddUserAsync(Users user)
        {
            _context.User.Add(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateUserAsync(Users user)
        {
            _context.User.Update(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if(user == null)
            {
                return 0;
            }
            _context.User.Remove(user);
            return await _context.SaveChangesAsync();
        }
    }
}
