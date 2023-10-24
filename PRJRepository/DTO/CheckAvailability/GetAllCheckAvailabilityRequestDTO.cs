using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.CheckAvailability
{
    public class GetAllCheckAvailabilityRequestDTO
    {
        public long CheckAvailabilityId { get; set; }

        public int? Duration { get; set; }

        public long? ClinicianId { get; set; }

        public int? LocationId { get; set; }

        public DateTime? SelectDate { get; set; }

        public bool? InsurranceAccept { get; set; }
    }
}
