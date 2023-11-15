using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.ServiceSetting
{
    public class EditServiceSettingResponseDTO
    {
        public long? ClinicId { get; set; }
        public long ServiceId { get; set; }

        public string? ServiceName { get; set; }

        public string? ServiceDescription { get; set; }

        public int? Cptcode { get; set; }

        public int? RatePerUnit { get; set; }

        public int? Duration { get; set; }

        public bool? IsDefaultService { get; set; }

        public int? PaymentType { get; set; }

        public bool? IsBookedforNewClient { get; set; }

        public bool? IsBookedforCurrentClient { get; set; }

        public int? MinutesBefore { get; set; }

        public int? MinutesAfter { get; set; }
    }
}
