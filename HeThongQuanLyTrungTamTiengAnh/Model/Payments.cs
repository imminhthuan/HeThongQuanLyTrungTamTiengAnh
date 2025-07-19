using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace HeThongQuanLyTrungTamTiengAnh.Model
{
    public class Payments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime PaidDate { get; set; } = DateTime.Now;

        [MaxLength(255)]
        public string Note { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Students Student { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Courses Courses { get; set; }

    }
}
