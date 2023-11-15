using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.ClinicLocation
{
    public class GetAllClinicLocationRequestDTO
    {
        public long ClinicLocationId { get; set; }

        public long? ClinicId { get; set; }

        public string? ShortName { get; set; }

        public string? LongName { get; set; }

        public string? Address { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? StateId { get; set; }

        public string? ZipCode { get; set; }

        public string? BillingAddress { get; set; }

        public string? Address1 { get; set; }

        public int? CountryId1 { get; set; }

        public int? CityId1 { get; set; }

        public int? StateId1 { get; set; }

        public string? ZipCode1 { get; set; }

        public int? IndividualOffice { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public string? Email { get; set; }

        public long? TaxId { get; set; }

        public long? Npi { get; set; }

        public long? Taxonomy { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int? ServicePlace { get; set; }

        public bool? Status { get; set; }
    }
}
