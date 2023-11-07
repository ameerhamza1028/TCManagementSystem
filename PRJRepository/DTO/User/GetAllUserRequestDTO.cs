using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.User
{
    public class GetAllUserRequestDTO
    {
        public long? ClinicId { get; set; }
        public int? UserType { get; set; }

        public long UserId { get; set; }

        public string? UserName { get; set; }

        public string? AddressType { get; set; }

        public string? Address { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? StateId { get; set; }

        public long? ZipCode { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int? Month { get; set; }
        public int? Day { get; set; }

        public long? Year { get; set; }

        public long? Npi { get; set; }

        public long? TaxId { get; set; }

        public int? Status { get; set; }

        public string? PrimaryWorkLocation { get; set; }

        public string? Malpractice { get; set; }

        public long? MalpracticePolicy { get; set; }

        public DateTime? MalpracticeExpDate { get; set; }

        public string? UploadFilePath { get; set; }

        public string? School { get; set; }

        public string? DegreeReceived { get; set; }

        public long? Caqhid { get; set; }

        public string? DefaultModifier { get; set; }

        public long? TaxonomyCode { get; set; }

        public string? Modifier1 { get; set; }

        public string? Modifier2 { get; set; }

        public string? Modifier3 { get; set; }
    }
}
