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


        // Tìm email dưới db 
        public async Task<Users> GetUserByEmailAsync(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Users> AddUserAsync(Users user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUserAsync(Users user)
        {
            _context.User.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if(user == null)
            {
                return false;
            }
            _context.User.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
