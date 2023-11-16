using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.ServiceSetting
{
    public class GetAllServiceSettingResponseDTO
    {
        public long ServiceId { get; set; }

        public string? ServiceName { get; set; }

        public string? ServiceDescription { get; set; }

        public int? Cptcode { get; set; }

        public int? RatePerUnit { get; set; }

        public int? Duration { get; set; }

        public int? ClinicianCount { get; set; }
    }
}
