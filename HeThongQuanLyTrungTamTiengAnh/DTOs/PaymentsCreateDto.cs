using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class PaymentsCreateDto
    {

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }

    }
}
