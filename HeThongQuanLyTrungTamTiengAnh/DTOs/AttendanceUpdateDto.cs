using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class AttendanceUpdateDto
    {
        [Required]
        public int AttendanceId { get; set; }

        public DateTime AttendanceDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }
    }
}
