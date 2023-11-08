using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Client
{
    public class EditClientResponseDTO
    {
        public long EditClientId { get; set; }

        public long? ClientId { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Suffix { get; set; }

        public string? NameToGoBy { get; set; }

        public bool? IsMinor { get; set; }

        public int? PrimaryClinicianId { get; set; }
        public bool? IsAppointments { get; set; }

        public bool? IsCompletingDocuments { get; set; }

        public string? ClientEmail { get; set; }

        public bool? IsReminderDayOne { get; set; }

        public bool? IsReminderDayTwo { get; set; }

        public bool? IsReminderDayThree { get; set; }

        public bool? IsReminderDayFive { get; set; }

        public bool? IsReminderWeek1 { get; set; }

        public int? LocationId { get; set; }

        public int? Month { get; set; }

        public int? Day { get; set; }

        public long? Year { get; set; }

        public int? Sex { get; set; }

        public string? GenderIdentity { get; set; }

        public int? RelationshipStatus { get; set; }

        public int? EmploymentStatus { get; set; }

        public bool? IsAmericanIndianOrAlaskaNatine { get; set; }

        public bool? IsAsian { get; set; }

        public bool? IsBlackOrAfricanAmerican { get; set; }

        public bool? IsHisoanicOrLatinix { get; set; }

        public bool? IsMiddleEasternOrNorthAfrican { get; set; }

        public bool? IsNativeHawaiianOrOtherPacificIslander { get; set; }

        public bool? IsWhite { get; set; }

        public bool? IsRaceOrEthnicityNotListed { get; set; }
    }
    

    
}

