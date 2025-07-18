using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeThongQuanLyTrungTamTiengAnh.Model
{
    public class Teachers
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email {  get; set; }

        [MaxLength(15)]
        public string Phone {  get; set; }

        [MaxLength(100)]
        public string Sepcialization { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Classes> Classess {  get; set; }


    }
}
