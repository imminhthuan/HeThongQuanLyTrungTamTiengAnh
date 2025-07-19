using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class ClassesUpdateDto
    {
        [Required]
        public int ClasseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClassesName { get; set; }

        [DataType(DataType.Date)]
        public DateTime StarDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [MaxLength(100)]
        public string Schedule { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
    }
}
