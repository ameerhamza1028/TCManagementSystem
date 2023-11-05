using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Client
{
    public long? OrganizationId { get; set; }

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

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public long? LoginId { get; set; }

    public long? ClinicId { get; set; }
}
