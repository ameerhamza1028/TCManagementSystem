using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.AvailableSlot
{
    public class GetAllSlotAvailableResponseDTO
    {
        public long AppointmntSlotId { get; set; }

        public bool? AppointmentRequest { get; set; }

        public string? Name { get; set; }

        public long? ClicianId { get; set; }

        public DateTime? SlotDate { get; set; }

        public TimeSpan? Time { get; set; }

        public int? Duration { get; set; }

        public bool? Repeat { get; set; }

        public int? Weeks { get; set; }

        public int? Days { get; set; }

        public bool? Inperson { get; set; }

        public long? InpersonlocationId { get; set; }

        public bool? Telehealth { get; set; }

        public int? LocationId { get; set; }

        public long? ServiceId { get; set; }

        public int? ServiceDuration { get; set; }

        public DateTime? CreationDate { get; set; }

        public long? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
