using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Tcuser
{
    public int ClientId { get; set; }

    public string? ClientType { get; set; }

    public string? FirstName1 { get; set; }

    public string? LastName1 { get; set; }

    public string? Email1 { get; set; }

    public bool? IsSendEmailReminder1 { get; set; }

    public bool? IsSendTextReminder1 { get; set; }

    public string? Phone1 { get; set; }

    public string? BilingType { get; set; }

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

    public bool? IsBilling { get; set; }

    public string? BillResponsible { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
