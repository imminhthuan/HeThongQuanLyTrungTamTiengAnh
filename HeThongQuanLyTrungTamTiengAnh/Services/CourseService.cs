using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseResponseDto> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if(course == null)
            {
                return null;
            }
            return _mapper.Map<CourseResponseDto>(course);
        }

        public async Task<IEnumerable<CourseResponseDto>> GetAllCourseAsync()
        {
            var course = await _courseRepository.GetAllCourseAsync();
            return _mapper.Map<IEnumerable<CourseResponseDto>>(course);
        }

        public async Task<CourseResponseDto> CreateCourseAsync(CourseCreateDto courseCreateDto)
        {
            var courseEntity = _mapper.Map<Courses>(courseCreateDto);
            courseEntity.CreatedAt = DateTime.Now;
            var Course = await _courseRepository.AddCourseAsync(courseEntity);
            return _mapper.Map<CourseResponseDto>(Course);
        }

        public async Task<bool> UpdateCourseAsync(CourseUpdateDto courseUpdateDto)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseUpdateDto.CourseId);
            if(course == null)
            {
                return false;
            }
            _mapper.Map(courseUpdateDto, course);
            return await _courseRepository.UpdateCourseAsync(course);
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course =await _courseRepository.GetCourseByIdAsync(id);
            if(course == null)
            {
                return false;
            }
            return await _courseRepository.DeleteCourseAsync(id);
        }
    }
}
