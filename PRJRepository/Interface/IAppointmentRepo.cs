using PRJRepository.DTO.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IAppointmentRepo
    {
        public List<GetAllAppointmentResponseDTO> GetAllAppointment();
        public bool SaveAppointment(GetAllAppointmentRequestDTO request);
        public GetAllAppointmentRequestDTO GetAppointmentById(long Id);
        public bool DeleteAppointment(long Id);
    }
}
