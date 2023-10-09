using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IAppointmentRepo
    {
        public List<GetAllAppointmentResponseDTO> GetAllAppointment();
        public bool SaveAppointment(GetAllAppointmentRequestDTO request);
        public GetAllAppointmentResponseDTO GetAppointmentById(int id);
        public bool DeleteAppointment(int id);
    }
}
