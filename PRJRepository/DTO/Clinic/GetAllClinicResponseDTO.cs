using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Clinic
{
    public class GetAllClinicResponseDTO
    {
       // public long? ClientId { get; set; }

        public long ClinicId { get; set; }

        public string? LongFacilityName { get; set; }

       // public string? ShortFacilityName { get; set; }


        public string? Address { get; set; }

        //public string? CityName { get; set; }

        //public string? StateName { get; set; }

        //public string? ZipCode { get; set; }

       // public string? BillingAddress { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public string? Email { get; set; }

        //public string? ContactName { get; set; }

        //public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public long? TaxId { get; set; }

        public long? Npi { get; set; }

        public long? Taxomony { get; set; }

        //public DateTime? ExpirationDate { get; set; }

        //public long? ServicePlaceId { get; set; }

        public bool? IsActive { get; set; }

        //public DateTime? CreationDate { get; set; }

        //public long? CreatedBy { get; set; }
    }
}
