using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Client
{
    public class GetAllClientResponseDTO
    {

        public string? FirstName1 { get; set; }

        public string? LastName1 { get; set; }

        public string? PrimaryClinicianName { get; set; }

        public string? Email1 { get; set; }

        public string? Phone1 { get; set; }

        public bool? IsSelfPay { get; set; }

        public bool? IsInsurance { get; set; }

        public long? InsuranceId { get; set; }

        public string? InsuranceName { get; set; }

        public DateTime? LastAppointment { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        
        public bool? Status { get; set; }
    }
}
