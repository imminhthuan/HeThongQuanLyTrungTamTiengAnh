using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeThongQuanLyTrungTamTiengAnh.Model
{
    public class Classes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClasseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClassesName { get; set; }

        [DataType(DataType.Date)]
        public DateTime StarDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [MaxLength(100)]
        public string Schedule {  get; set; }

        public int CourseId { get; set; }

        public int TeacherId { get; set; }

        [ForeignKey("CourseId")]
        public Courses Courses { get; set; }

        [ForeignKey("TeacherId")]
        public Teachers Teachers { get; set; }

        public ICollection<StudentClasses> StudentClasses { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
