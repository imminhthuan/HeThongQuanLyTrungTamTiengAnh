using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    public class UserUpdateDto
    {
        [Required]
        public int UserId { get; set; } // Cần ID để xác định user nào được cập nhật

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }
    }
}
