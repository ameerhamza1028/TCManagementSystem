using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.EditClient
{
    public class SaveEditClientResponseDTO
    {

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? ClinicianName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? ClientEmail { get; set; }

        public long? AddressId { get; set; }

        public bool? IsSelfPay { get; set; }

        public bool? IsInsurrance { get; set; }

        public long? InsuranceId { get; set; }

        public int? InsuranceType { get; set; }

        public DateTime? IntakeDate { get; set; }

        public string? LastAppointment {  get; set; }

        public bool? Status { get; set; }
    }
}
