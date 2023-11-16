using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Appointment
{
    public class GetAllAppointmentRequestDTO
    {
        public long AppointmentId { get; set; }

        public long ClientId { get; set; }

        public int? AppointmentType { get; set; }

        public bool? AllDay { get; set; }

        public DateTime? Date { get; set; }

        public string? Time { get; set; }

        public int? Duration { get; set; }

        public long? ClicianId { get; set; }

        public string? Location { get; set; }

        public bool? Repeat { get; set; }

        public string? VirtualLocationId { get; set; }

        public long? ServiceId { get; set; }
    }
}
