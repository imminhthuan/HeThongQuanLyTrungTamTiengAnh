using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTrungTamTiengAnh.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }


        public async Task<StudentResponseDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if(student == null)
            {
                return null;
            }

            return _mapper.Map<StudentResponseDto>(student);
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllStudentAsync()
        {
            var student = await _studentRepository.GetAllStudentAsync();
            return _mapper.Map<IEnumerable<StudentResponseDto>>(student);
        }

        public async Task<StudentResponseDto> CreateStudentAsync(StudentCreateDto studentCreateDto)
        {
            var student = await _studentRepository.GetStudentEmailAsync(studentCreateDto.Email);
            if(student != null)
            {
                throw new ApplicationException("Email already exists.");
            }

            var studentEntity = _mapper.Map<Students>(studentCreateDto);
            var createStudent = await _studentRepository.AddStudentAsync(studentEntity);
            return _mapper.Map<StudentResponseDto>(createStudent);
        }

        public async Task<bool> UpdateStudentAsync(StudentUpdateDto studentUpdateDto)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentUpdateDto.StudentId);
            if(student == null)
            {
                return false;
            }
            _mapper.Map(studentUpdateDto, student);
            return await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if(student == null)
            {
                return false;
            }
            return await _studentRepository.DeleteStudentAsync(id);
        }
    }
}
