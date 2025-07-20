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

            // Classes
            CreateMap<Classes, ClassesResponseDto>()
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Courses))
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teachers));
            CreateMap<ClassesCreateDto, Classes>();
            CreateMap<ClassesUpdateDto, Classes>();

            // Attendance
            CreateMap<Attendance, AttendanceResponseDto>()
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.Classes, opt => opt.MapFrom(src => src.Classess));
            CreateMap<AttendanceCreateDto, Attendance>()
                .ForMember(dest => dest.AttendanceDate, opt => opt.Ignore());
            CreateMap<AttendanceUpdateDto, Attendance>();


            // Courses
            CreateMap<Courses, CourseResponseDto>();
            CreateMap<CourseCreateDto, Courses>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<CourseUpdateDto, Courses>();


        }
    }
}
