using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTrungTamTiengAnh.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Payments> GetPaymentByIdAsync(int id)
        {
            return await _context.Payment.FindAsync(id);
        }

        public async Task<IEnumerable<Payments>> GetAllPaymentAsync()
        {
            return await _context.Payment.ToListAsync();
        }

        public async Task<int> AddPaymentAsync(Payments payments)
        {
            _context.Payment.Add(payments);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePaymentAsync(Payments payments)
        {
            _context.Payment.Update(payments);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePaymentAsync(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if(payment == null)
            {
                return 0;
            }
            _context.Payment.Remove(payment);
            return await _context.SaveChangesAsync();
        }
    }
}
