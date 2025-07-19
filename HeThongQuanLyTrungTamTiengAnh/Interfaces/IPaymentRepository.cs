using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payments> GetPaymentByIdAsync(int id);
        Task<IEnumerable<Payments>> GetAllPaymentAsync();
        Task<int> AddPaymentAsync(Payments payments);
        Task<int> UpdatePaymentAsync(Payments payments);
        Task<int> DeletePaymentAsync(int id);
    }
}
