using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class AttendanceCreateDto
    {
        [MaxLength(20)]
        public string Status { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int ClassId { get; set; }
    }
}
