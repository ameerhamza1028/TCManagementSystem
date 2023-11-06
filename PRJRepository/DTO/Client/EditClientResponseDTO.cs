﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Client
{
    public class EditClientResponseDTO
    {
       // public long? OrganizationId { get; set; }

        public long ClientId { get; set; }

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

        public string? PrimaryClinicianName { get; set; }

        public string? Location { get; set; }

        public string? FirstName2 { get; set; }

        public string? LastName2 { get; set; }

        public string? Email2 { get; set; }

        public string? Phone2 { get; set; }

        public bool? IsSendEmailRemainder2 { get; set; }

        public bool? IsSendTextRemainder2 { get; set; }

        public bool? IsSendVoiceRemainder2 { get; set; }

        public string? Relationship { get; set; }

        public bool? IsResponsibleForBilling { get; set; }

        public string? BillResponsibleClient { get; set; }

        public bool? Status { get; set; }
    }
}