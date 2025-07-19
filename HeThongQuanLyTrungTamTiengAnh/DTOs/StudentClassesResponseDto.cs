using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class StudentClassesResponseDto
    {
        public int StudentClassesId { get; set; }
        public int StudentId { get; set; }
        public int ClasseId { get; set; }
        public DateTime EnrolledAt { get; set; }
        public StudentResponseDto Student {  get; set; }
        public ClassesResponseDto Classe { get; set; }
    }
}
