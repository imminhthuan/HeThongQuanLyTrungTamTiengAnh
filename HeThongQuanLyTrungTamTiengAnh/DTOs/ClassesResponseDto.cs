using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class ClassesResponseDto
    {
        public int ClasseId { get; set; }
        public string ClassesName { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Schedule { get; set; }

        public int CourseId { get; set; }

        public int TeacherId { get; set; }
        public CourseResponseDto Course { get; set; }
        public TeacherResponseDto Teacher { get; set; }
    }
}
