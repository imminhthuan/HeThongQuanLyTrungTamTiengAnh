using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payments> GetPaymentByIdAsync(int id);
        Task<IEnumerable<Payments>> GetPaymentAsync();
        Task AddPaymentAsync(Payments payments);
        Task UpdatePaymentAsync(Payments payments);
        Task DeletePaymentAsync(int id);
    }
}
