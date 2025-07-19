using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class AttendanceResponseDto
    {
        public int AttendanceId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public StudentResponseDto Student {  get; set; }
        public ClassesResponseDto Classes { get; set; }
    }
}
