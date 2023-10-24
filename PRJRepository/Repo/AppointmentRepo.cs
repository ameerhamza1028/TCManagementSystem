using AutoMapper;
using PRJRepository.DTO.Appointment;
using PRJRepository.Interface;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public AppointmentRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllAppointmentResponseDTO> GetAllAppointment()
        {
            List<GetAllAppointmentResponseDTO> response = new List<GetAllAppointmentResponseDTO>();
            List<Appointment> list = _context.Appointments.ToList();
            response = _mapper.Map<List<GetAllAppointmentResponseDTO>>(list);
            return response;
        }

        public GetAllAppointmentResponseDTO GetAppointmentById(long Id)
        {
            GetAllAppointmentResponseDTO response = new GetAllAppointmentResponseDTO();
            Appointment item = _context.Appointments.Where(x => x.AppointmentId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllAppointmentResponseDTO>(item);
            return response;
        }

        public bool SaveAppointment(GetAllAppointmentRequestDTO request)
        {
            try
            {
                Appointment appointment = new Appointment();
                if (request.AppointmentId == 0)
                {
                    appointment = _mapper.Map<Appointment>(request);
                    appointment.IsActive = true;
                    appointment.CreationDate = DateTime.UtcNow;
                    _context.Appointments.Add(appointment);
                    _context.SaveChanges();
                }
                else
                {
                    appointment = _context.Appointments.Where(x => x.AppointmentId == request.AppointmentId).FirstOrDefault();
                    appointment = _mapper.Map(request, appointment);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAppointment(long Id)
        {
            try
            {
                Appointment appointment = _context.Appointments.FirstOrDefault(x => x.AppointmentId == Id);
                appointment.IsActive=false;
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
