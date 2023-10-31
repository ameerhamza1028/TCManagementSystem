using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Service
{
    public class GetAllServiceRequestDTO
    {
        public long ServiceId { get; set; }

        public string? ServiceName { get; set; }

        public int? ServiceDuration { get; set; }

        public decimal? RatePerUnit { get; set; }

        public string? Modifier1 { get; set; }

        public string? Modifier2 { get; set; }

        public string? Modifier3 { get; set; }

        public string? Modifier4 { get; set; }

        public long? CreatedBy { get; set; }
    }
}
