using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;

namespace HeThongQuanLyTrungTamTiengAnh.Services
{
    public class ClassesService : IClassesService
    {
        private readonly IClassesRepository _classesRepository;
        private readonly IMapper _mapper;

        public ClassesService(IClassesRepository classesRepository, IMapper mapper)
        {
            _classesRepository = classesRepository;
            _mapper = mapper;
        }

        public async Task<ClassesResponseDto> GetClassesByIdAsync(int id)
        {
            var classes = await _classesRepository.GetClassesByIdAsync(id);
            if(classes == null)
            {
                return null;
            }
            return _mapper.Map<ClassesResponseDto>(classes);
        }

        public async Task<IEnumerable<ClassesResponseDto>> GetAllClassesAsync()
        {
            var classes = await _classesRepository.GetAllClassesAsync();
            return _mapper.Map<IEnumerable<ClassesResponseDto>>(classes);

        }

        public async Task<ClassesResponseDto> CreateClassesAsync(ClassesCreateDto classesCreateDto)
        {
            var classesEntity = _mapper.Map<Classes>(classesCreateDto);
            var classes = await _classesRepository.AddClassesAsync(classesEntity);
            return _mapper.Map<ClassesResponseDto>(classes);
        }

        public async Task<bool> UpdateClassesAsync(ClassesUpdateDto classesUpdateDto)
        {
            var classes = await _classesRepository.GetClassesByIdAsync(classesUpdateDto.ClasseId);
            if(classes == null)
            {
                return false;
            }
            _mapper.Map(classesUpdateDto, classes);
            return await _classesRepository.UpdateClassesAsync(classes);
        }

        public async Task<bool> DeleteClassesAsync(int id)
        {
            var classes = await _classesRepository.GetClassesByIdAsync(id);
            if(classes == null)
            {
                return false;
            }
            return await _classesRepository.DeleteClassesAsync(id);
        }
    }
}
