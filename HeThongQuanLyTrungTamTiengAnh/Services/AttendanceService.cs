using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Repositories;

namespace HeThongQuanLyTrungTamTiengAnh.Services
{
    public class AttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<AttendanceResponseDto> GetAttendanceByIdAsync(int id)
        {
            var attendancse = await _attendanceRepository.GetAttendanceByIdAsync(id);
            if(attendancse == null)
            {
                return null;            
            }
            return _mapper.Map<AttendanceResponseDto>(attendancse);
        }
    }
}
