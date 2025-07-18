using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeThongQuanLyTrungTamTiengAnh.Model
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName {  get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email {  get; set; }

        [Required]
        [MaxLength(255)]
        public string Passwordhash { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // tự đóng gán ngày tạo khi tạo bản ghi mới
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
