using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class StudentClassesUpdateDto
    {
        [Required]
        public int StudentClassesId { get; set; }
        public DateTime EnrolledAt { get; set; }
    }
}
