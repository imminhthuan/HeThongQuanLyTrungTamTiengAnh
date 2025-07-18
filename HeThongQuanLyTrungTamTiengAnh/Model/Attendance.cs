using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeThongQuanLyTrungTamTiengAnh.Model
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }

        public DateTime AttendanceDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }
        

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Students Student { get; set; }

        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Classes Classes { get; set; }

    }
}
