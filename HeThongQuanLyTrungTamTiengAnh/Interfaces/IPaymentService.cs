using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IPaymentService
    {
        Task<Payments> GetPaymentByIdAsync(int id);
        Task<IEnumerable<Payments>> GetAllPaymentAsync();
        Task<Payments> CreatePaymentAsync(Payments payments);
        Task UpdatePaymentAsync(Payments payments);
        Task DeletePaymentAsync(int id);
    }
}
