using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payments> GetPaymentByIdAsync(int id);
        Task<IEnumerable<Payments>> GetAllPaymentAsync();
        Task<Payments> AddPaymentAsync(Payments payments);
        Task<bool> UpdatePaymentAsync(Payments payments);
        Task<bool> DeletePaymentAsync(int id);
    }
}
