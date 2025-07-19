using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _eacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _eacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<TeacherResponseDto> GetTeacherByIdAsync(int id)
        {
            var teacher = await _eacherRepository.GetTeacherByIdAsync(id);
            if(teacher == null)
            {
                return null;
            }
            return _mapper.Map<TeacherResponseDto>(teacher);
        }

        public async Task<IEnumerable<TeacherResponseDto>> GetAllTeacherAsync()
        {
            var teacher = await _eacherRepository.GetAllTeacherAsync();
            return _mapper.Map<IEnumerable<TeacherResponseDto>>(teacher);
        }

        public async Task<TeacherResponseDto> CreateTeacherAsync(TeacherCreateDto teacherCreateDto)
        {
            var emails = await _eacherRepository.GetTeacherEmailAsync(teacherCreateDto.Email);
            if(emails != null)
            {
                throw new ApplicationException("Email already exists.");
            }

            var teacherEntity = _mapper.Map<Teachers>(teacherCreateDto);
            var createTeacher = await _eacherRepository.AddTeacherAsync(teacherEntity);
            return _mapper.Map<TeacherResponseDto>(createTeacher);
        }

        public async Task<bool> UpdateTeacherAsync(TeacherUpdateDto teacherUpdateDto)
        {
            var teacher = await _eacherRepository.GetTeacherByIdAsync(teacherUpdateDto.TeacherId);
            if(teacher == null)
            {
                return false;
            }
            _mapper.Map(teacherUpdateDto, teacher);
            return await _eacherRepository.UpdateTeacherAsync(teacher);
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await _eacherRepository.GetTeacherByIdAsync(id);
            if(teacher == null)
            {
                return false;
            }
            return await _eacherRepository.DeleteTeacherAsync(id);
        }

    }
}
