using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.AvailableSlot
{
    public class GetAllAvailableSlotRequestDTO
    {
        public long AppointmntSlotId { get; set; }

        public bool? IsAppointmentRequest { get; set; }

        public string? Name { get; set; }

        public long? ClicianId { get; set; }

        public DateTime? SlotDate { get; set; }

        public string? StartTime { get; set; }

        public string? EndTime { get; set; }

        public int? Duration { get; set; }

        public bool? IsRepeat { get; set; }

        public int? Weeks { get; set; }

        public int? Days { get; set; }

        public int? EndAt { get; set; }

        public bool? Inperson { get; set; }

        public string? InpersonlocationId { get; set; }

        public bool? Telehealth { get; set; }

        public string? Location { get; set; }

        public long? ServiceId { get; set; }

        public int? ServiceDuration { get; set; }
    }
}
