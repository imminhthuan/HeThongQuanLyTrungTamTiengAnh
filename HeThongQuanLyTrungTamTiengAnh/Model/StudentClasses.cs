using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeThongQuanLyTrungTamTiengAnh.Model
{
    public class StudentClasses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentClassesId { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Students Students { get; set; }

        public int ClasseId { get; set; }
        [ForeignKey("ClasseId")]
        public Classes Classes { get; set; }
    }
}
