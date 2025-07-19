using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidDate { get; set; } = DateTime.Now;
        public string Note { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public StudentResponseDto Student { get; set; }
        public CourseResponseDto Course { get; set; }
    }
}
