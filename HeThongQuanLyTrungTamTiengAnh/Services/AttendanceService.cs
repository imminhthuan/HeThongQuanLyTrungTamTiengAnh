using AutoMapper;
using HeThongQuanLyTrungTamTiengAnh.DTOs;
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Model;
using HeThongQuanLyTrungTamTiengAnh.Repositories;

namespace HeThongQuanLyTrungTamTiengAnh.Services
{
    public class AttendanceService : IAttendanceService
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

        public async Task<IEnumerable<AttendanceResponseDto>> GetAllAttendanceAsync()
        {
            var attendance = await _attendanceRepository.GetAllAttendanceAsync();
            return _mapper.Map<IEnumerable<AttendanceResponseDto>>(attendance);
        }

        public async Task<AttendanceResponseDto> CreateAttendanceAsync(AttendanceCreateDto attendanceCreateDto)
        {
            var attendanceEntity = _mapper.Map<Attendance>(attendanceCreateDto);
            attendanceEntity.AttendanceDate = DateTime.Now;
            var attendance = await _attendanceRepository.AddAttendanceAsync(attendanceEntity);
            return _mapper.Map<AttendanceResponseDto>(attendance);
        }

        public async Task<bool> UpdateAttendanceAsync(AttendanceUpdateDto attendanceUpdateDto)
        {
            var attendance = await _attendanceRepository.GetAttendanceByIdAsync(attendanceUpdateDto.AttendanceId);
            if(attendance == null)
            {
                return false;
            }
            _mapper.Map(attendanceUpdateDto, attendance);
            return await _attendanceRepository.UpdateAttendanceAsync(attendance);
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var attendance = await _attendanceRepository.GetAttendanceByIdAsync(id);
            if(attendance == null)
            {
                return false;
            }
            return await _attendanceRepository.DeleteAttendanceAsync(id);
        }
    }
}
