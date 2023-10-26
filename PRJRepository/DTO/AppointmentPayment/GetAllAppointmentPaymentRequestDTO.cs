using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.AppointmentPayment
{
    public class GetAllAppointmentPaymentRequestDTO
    {
        public long AppointmentPaymentId { get; set; }

        public string? ClientName { get; set; }

        public long? Cptcode { get; set; }

        public decimal? Billed { get; set; }

        public decimal? ClientOwes { get; set; }

        public decimal? InsurancePaid { get; set; }

        public decimal? WriteOff { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public long? Createdby { get; set; }
    }
}
