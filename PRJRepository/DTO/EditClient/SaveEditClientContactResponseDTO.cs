using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.EditClient
{
    public class SaveEditClientContactResponseDTO
    {
       // public long? ClientId { get; set; }

        public long ContactId { get; set; }

        public string? ContactFirstName { get; set; }

        public string? ContactMiddleName { get; set; }

        public string? ContactLastName { get; set; }

        public string? ContactSuffix { get; set; }

        public string? ContactNameGoBy { get; set; }

        public string? ContactRelationshipStatus { get; set; }

        public bool? IsEmergencyContact { get; set; }

        public string? Notes { get; set; }
    }
}
