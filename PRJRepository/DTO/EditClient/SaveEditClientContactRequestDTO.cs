using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.EditClient
{
    public class SaveEditClientContactRequestDTO
    {
        public long? ClientId { get; set; }

        public long ContactId { get; set; }

        public string? ContactFirstName { get; set; }

        public string? ContactMiddleName { get; set; }

        public string? ContactLastName { get; set; }

        public string? ContactSuffix { get; set; }

        public string? ContactNameGoBy { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactEmailType { get; set; }

        public bool? IsAccessToClientPortal { get; set; }

        public string? ContactRelationshipStatus { get; set; }

        public bool? IsEmergencyContact { get; set; }

        public List<Phone2DTO>? Phone { get; set; }

        public List<Address2DTO>? Address { get; set; }

        public string? Notes { get; set; }
    }

    public class Phone2DTO
    {

        public long PhoneId { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PhoneType { get; set; }

        public bool? IsSendTextMessage { get; set; }

        public bool? IsSendVoiceMessage { get; set; }
    }

    public class Address2DTO
    {
        public long AddressId { get; set; }

        public string? Address1 { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? StateId { get; set; }

        public long? ZipCode { get; set; }
    }
}
