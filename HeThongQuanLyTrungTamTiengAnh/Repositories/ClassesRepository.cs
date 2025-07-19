using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTrungTamTiengAnh.Repositories
{
    public class ClassesRepository : IClassesRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassesRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Classes> GetClassesByIdAsync(int id)
        {
            return await _context.Classe.FindAsync(id);
        }

        public async Task<IEnumerable<Classes>> GetAllClassesAsync()
        {
            return await _context.Classe.ToListAsync();
        }

        public async Task<int> AddClassesAsync(Classes classes)
        {
            _context.Classe.Add(classes);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateClassesAsync(Classes classes)
        {
            _context.Classe.Update(classes);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteClassesAsync(int id)
        {
            var classes = await _context.Classe.FindAsync(id);
            if(classes == null)
            {
                return 0;
            }
            _context.Classe.Remove(classes);
            return await _context.SaveChangesAsync();
        }

    }
}
