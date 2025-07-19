using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class StudentClassesCreateDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int ClasseId { get; set; }
    }
}
