using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class CourseUpdateDto
    {
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CoursesName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal TuitionFee { get; set; }
        public int DurationWeeks { get; set; } // thời lượng học trong bao lâu 
    }
}
