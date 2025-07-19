namespace HeThongQuanLyTrungTamTiengAnh.DTOs
{
    // tra ve Client
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
