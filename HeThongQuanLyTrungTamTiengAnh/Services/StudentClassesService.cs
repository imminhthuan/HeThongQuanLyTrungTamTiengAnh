using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Services
{
    public class StudentClassesService : IStudentClassesService
    {
        private readonly IStudentClassesRepository _studentClassesRepository;
        private readonly IMapper _mapper;

        public StudentClassesService(IStudentClassesRepository studentClassesRepository, IMapper mapper)
        {
            _studentClassesRepository = studentClassesRepository;
            _mapper = mapper;
        }

        public async Task<StudentClassesResponseDto> GetStudentClassesByIdAsync(int id)
        {
            var studentclasses = await _studentClassesRepository.GetStudentClassesByIdAsync(id);
            if(studentclasses == null)
            {
                return null;
            }

            return _mapper.Map<StudentClassesResponseDto>(studentclasses);
        }

        public async Task<IEnumerable<StudentClassesResponseDto>> GetAllStudentClassesAsync()
        {
            var studentClasses = await _studentClassesRepository.GetAllStudentCalssesAsync();
            return _mapper.Map<IEnumerable<StudentClassesResponseDto>>(studentClasses);
        }

        public async Task<StudentClassesResponseDto> CreateStudentClassesAsync(StudentClassesCreateDto studentClassesCreateDto)
        {
            var studentClassesEntity = _mapper.Map<StudentClasses>(studentClassesCreateDto);
            studentClassesEntity.EnrolledAt = DateTime.Now;
            var studentClasses = await _studentClassesRepository.AddStudentClassesAsync(studentClassesEntity);
            return _mapper.Map<StudentClassesResponseDto>(studentClasses);
        }

        public async Task<bool> UpdateStudentClassesAsync(StudentClassesUpdateDto studentClassesUpdateDto)
        {
            var studenclasses = await _studentClassesRepository.GetStudentClassesByIdAsync(studentClassesUpdateDto.StudentClassesId);
            if(studenclasses == null)
            {
                return false;
            }
            _mapper.Map(studentClassesUpdateDto, studenclasses);
            return await _studentClassesRepository.UpdateStudentClassesAsync(studenclasses);
        }

        public async Task<bool> DeleteStudentClassesAsync(int id)
        {
            var studentClasses = await _studentClassesRepository.GetStudentClassesByIdAsync(id);
            if(studentClasses == null)
            {
                return false;
            }
            return await _studentClassesRepository.DeleteStudentClassesAsync(id);
        }
    }
}
