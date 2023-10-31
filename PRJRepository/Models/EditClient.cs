using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class EditClient
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

    public long? PhoneId { get; set; }

    public bool? IsAppointments { get; set; }

    public bool? IsCompletingDocuments { get; set; }

    public string? ClientEmail { get; set; }

    public bool? IsReminderDayOne { get; set; }

    public bool? IsReminderDayTwo { get; set; }

    public bool? IsReminderDayThree { get; set; }

    public bool? IsReminderDayFive { get; set; }

    public bool? IsReminderWeek1 { get; set; }

    public int? LocationId { get; set; }

    public long? AddressId { get; set; }

    public string? Month { get; set; }

    public int? Day { get; set; }

    public long? Year { get; set; }

    public string? Sex { get; set; }

    public string? GenderIdentity { get; set; }

    public string? RelationshipStatus { get; set; }

    public string? EmploymentStatus { get; set; }

    public bool? IsAmericanIndianOrAlaskaNatine { get; set; }

    public bool? IsAsian { get; set; }

    public bool? IsBlackOrAfricanAmerican { get; set; }

    public bool? IsHisoanicOrLatinix { get; set; }

    public bool? IsMiddleEasternOrNorthAfrican { get; set; }

    public bool? IsNativeHawaiianOrOtherPacificIslander { get; set; }

    public bool? IsWhite { get; set; }

    public bool? IsRaceOrEthnicityNotListed { get; set; }

    public int? ServiceId { get; set; }

    public long? ContactEmailId { get; set; }

    public string? Notes { get; set; }

    public bool? IsSelfPay { get; set; }

    public bool? IsInsurrance { get; set; }

    public bool? IsAutoPayEnrolled { get; set; }

    public long? CardId { get; set; }

    public long? InsuranceId { get; set; }

    public bool? IsCreateMonthlyStatements { get; set; }

    public bool? IsCreateMonthlySuperBills { get; set; }

    public string? EmailNotification { get; set; }

    public bool? IsNotifyNewInvoices { get; set; }

    public bool? IsNotifyNewStatements { get; set; }

    public bool? IsNotifyNewSuperBills { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
