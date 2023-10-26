using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Client
{
    public class GetAllClientResponseDTO
    {
        public long ClientId { get; set; }

        public long? CoupleId { get; set; }

        public bool? IsAdult { get; set; }

        public bool? IsMinor { get; set; }

        public bool? IsCouple { get; set; }

        public string? FirstName1 { get; set; }

        public string? LastName1 { get; set; }

        public string? Email1 { get; set; }

        public bool? IsSendEmailReminder1 { get; set; }

        public bool? IsSendTextReminder1 { get; set; }

        public string? Phone1 { get; set; }

        public bool? IsSelfPay { get; set; }

        public bool? IsInsurance { get; set; }

        public long? PrimaryClinicId { get; set; }

        public long? LocationId { get; set; }

        public string? FirstName2 { get; set; }

        public string? LastName2 { get; set; }

        public string? Email2 { get; set; }

        public string? Phone2 { get; set; }

        public bool? IsSendEmailRemainder2 { get; set; }

        public bool? IsSendTextRemainder2 { get; set; }

        public bool? IsSendVoiceRemainder2 { get; set; }

        public string? Relationship { get; set; }

        public bool? IsResponsibleForBilling { get; set; }

        public long? BillResponsibleClientId { get; set; }

        public bool? IsPotentialClient { get; set; }

        public bool? IsArchivedClient { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
