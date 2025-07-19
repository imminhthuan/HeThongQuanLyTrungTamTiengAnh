using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;

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


    }
}
