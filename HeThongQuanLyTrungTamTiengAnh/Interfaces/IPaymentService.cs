using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> GetPaymentByIdAsync(int id);
        Task<IEnumerable<PaymentResponseDto>> GetAllPaymentAsync();
        Task<PaymentResponseDto> CreatePaymentAsync(PaymentsCreateDto paymentsCreateDto);
        Task<bool> UpdatePaymentAsync(PaymentUpdateDto paymentUpdateDto);
        Task<bool> DeletePaymentAsync(int id);
    }
}
