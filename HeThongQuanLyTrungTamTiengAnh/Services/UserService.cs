using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;
using BCrypt.Net;

namespace HeThongQuanLyTrungTamTiengAnh.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper; // Ịnject AutoMapper

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        // Băm mật khẩu sử dụng thuật toán BCrypt
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        // Xác minh mật khẩu người dùng nhập vào so với mật khẩu đã băm lưu trong DB.
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        // Get All
        public async Task<IEnumerable<UserResponseDto>> GetAllUserAsync()
        {
            var users = await _userRepository.GetAllUserAsync(); // Repository trả về List<Users> entity
            return _mapper.Map<IEnumerable<UserResponseDto>>(users); // Map từ List<Users> sang List<UserResponseDto>
        }

        public async Task<UserResponseDto> GetUserByIdAsync(int id)
        {
            var users = await _userRepository.GetUserByIdAsync(id);
            if(users == null)
            {
                return null;
            }
            return _mapper.Map<UserResponseDto>(users);
        }

        public async Task<UserResponseDto> CreateUserAsync(UserCreateDto userCreateDto)
        {
            // logic kiem tra Email có trùng lặp
            var existingUser = await _userRepository.GetUserByEmailAsync(userCreateDto.Email);
            if(existingUser != null)
            {
                throw new ApplicationException("Email already exists.");
            }

            // Ánh xạ DTO sang Entity Model
            var userEntity = _mapper.Map<Users>(userCreateDto);

            // Xử lý mật khẩu (hash) và thời gian tạo
            userEntity.Passwordhash = HashPassword(userCreateDto.Passwordhash);
            userEntity.CreatedAt = DateTime.Now; // Tự động gán thời gian tạo

            var createUser = await _userRepository.AddUserAsync(userEntity);
            return _mapper.Map<UserResponseDto>(createUser);
        }

        public async Task<bool> UpdateUserAsync(UserUpdateDto usersUpdateDto)
        {
            var userUpdate = await _userRepository.GetUserByIdAsync(usersUpdateDto.UserId);
            if(userUpdate == null)
            {
                return false;
            }

            // Ánh xạ các trường từ UserUpdateDto sang Users entity hiện có
            _mapper.Map(usersUpdateDto, userUpdate);
            return await _userRepository.UpdateUserAsync(userUpdate);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var userDelete = await _userRepository.GetUserByIdAsync(id);
            if(userDelete == null)
            {
                return false;
            }

            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
