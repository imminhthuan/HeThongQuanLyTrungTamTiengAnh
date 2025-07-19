using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class CourseResponseDto
    {
        public int CourseId { get; set; }
        public string CoursesName { get; set; }
        public string Description { get; set; }
        public decimal TuitionFee { get; set; }
        public int DurationWeeks { get; set; } // thời lượng học trong bao lâu 
        public DateTime CreatedAt { get; set; }
    }
}
