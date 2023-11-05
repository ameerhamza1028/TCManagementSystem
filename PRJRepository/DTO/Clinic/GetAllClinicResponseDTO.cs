using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Clinic
{
    public class GetAllClinicResponseDTO
    {

        public long ClinicId { get; set; }

        public string? LongFacilityName { get; set; }

        public string? Address { get; set; }


        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public string? Email { get; set; }


        public string? ContactPhone { get; set; }

        public long? TaxId { get; set; }

        public long? Npi { get; set; }

        public long? Taxomony { get; set; }


        public bool? Message { get; set; }

        public bool? Status { get; set; }


    }
}
