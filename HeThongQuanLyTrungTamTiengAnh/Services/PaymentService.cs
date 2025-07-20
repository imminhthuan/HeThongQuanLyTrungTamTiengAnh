using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentResponseDto> GetPaymentByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if(payment == null)
            {
                return null;
            }
            return _mapper.Map<PaymentResponseDto>(payment);
        }

        public async Task<IEnumerable<PaymentResponseDto>> GetAllPaymentAsync()
        {
            var payment = await _paymentRepository.GetAllPaymentAsync();
            return _mapper.Map<IEnumerable<PaymentResponseDto>>(payment);
        }

        public async Task<PaymentResponseDto> CreatePaymentAsync(PaymentsCreateDto paymentsCreateDto)
        {
            var paymentEnity = _mapper.Map<Payments>(paymentsCreateDto);
            paymentEnity.PaidDate = DateTime.Now;
            var payment = await _paymentRepository.AddPaymentAsync(paymentEnity);
            return _mapper.Map<PaymentResponseDto>(payment);

        }

        public async Task<bool> UpdatePaymentAsync(PaymentUpdateDto paymentUpdateDto)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(paymentUpdateDto.PaymentId);
            if(payment == null)
            {
                return false;
            }
            _mapper.Map(paymentUpdateDto, payment);
            return await _paymentRepository.UpdatePaymentAsync(payment);
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if(payment == null)
            {
                return false;
            }
            return await _paymentRepository.DeletePaymentAsync(id);
        }
    }
}
