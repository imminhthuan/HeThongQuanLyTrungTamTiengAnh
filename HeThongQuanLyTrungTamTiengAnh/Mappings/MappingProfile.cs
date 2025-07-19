using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Model;


namespace HeThongQuanLyTrungTamTiengAnh.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity -> Response DTO (để trả về dữ liệu)
            CreateMap<Users, UserResponseDto>();

            // Create DTO -> Entity (để nhận dữ liệu đầu vào)
            CreateMap<UserCreateDto, Users>()
                .ForMember(dest => dest.Passwordhash, opt => opt.Ignore()) // PasswordHash sẽ được xử lý thủ công
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()); // CreatedAt sẽ được gán thủ công

            CreateMap<UserUpdateDto, Users>();


            // Teacher
            CreateMap<Teachers, TeacherResponseDto>();
            CreateMap<TeacherCreateDto, Teachers>();
            CreateMap<TeacherUpdateDto, Teachers>();

            // Student
            CreateMap<Students, StudentResponseDto>();
            CreateMap<StudentCreateDto, Students>();
            CreateMap<StudentUpdateDto, Students>();

            // StudentClasses
            CreateMap<StudentClasses, StudentClassesResponseDto>()
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.Classe, opt => opt.MapFrom(src => src.Classes));
            CreateMap<StudentClassesCreateDto, StudentClasses>();
            CreateMap<StudentClassesUpdateDto, StudentClasses>();



        }
    }
}
