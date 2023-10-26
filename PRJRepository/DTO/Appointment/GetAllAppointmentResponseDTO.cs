using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Appointment
{
    public class GetAllAppointmentResponseDTO
    {
        //public int AppointmentId { get; set; }

        //public long ClientId { get; set; }

        public string? ClientName { get; set; }

        //public bool? IsClientAppointment { get; set; }

        //public bool? IsOther { get; set; }

        //public bool? AllDay { get; set; }

        public DateTime? Date { get; set; }

        //public string? Time { get; set; }

        //public int? Duration { get; set; }

        //public long? ClicianId { get; set; }

        public long? LocationId { get; set; }

        //public bool? Repeat { get; set; }

        //public long? VirtualLocationId { get; set; }

        //public int? ServiceId { get; set; }

        //public DateTime? CreationDate { get; set; }

        //public long? CreatedBy { get; set; }

        //public bool? IsActive { get; set; }
    }
}
