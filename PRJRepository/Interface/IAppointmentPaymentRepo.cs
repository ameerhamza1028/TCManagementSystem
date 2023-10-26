using PRJRepository.DTO.AppointmentPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IAppointmentPaymentRepo
    {
        public List<GetAllAppointmentPaymentResponseDTO> GetAllAppointmentPayment();
        public GetAllAppointmentPaymentResponseDTO GetAppointmentPaymentById(long Id);
        public bool SaveAppointmentPayment(GetAllAppointmentPaymentRequestDTO request);
        public bool DeleteAppointmentPayment(long Id);
    }
}
