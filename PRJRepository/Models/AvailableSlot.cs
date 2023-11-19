using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class AvailableSlot
{
    public long AppointmntSlotId { get; set; }

    public bool? IsAppointmentRequest { get; set; }

    public string? Name { get; set; }

    public long? ClicianId { get; set; }

    public DateTime? SlotDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public TimeSpan? TotalTime { get; set; }

    public int? Duration { get; set; }

    public bool? IsRepeat { get; set; }

    public int? Weeks { get; set; }

    public int? Days { get; set; }

    public int? EndAt { get; set; }

    public bool? Inperson { get; set; }

    public string? InpersonlocationId { get; set; }

    public bool? Telehealth { get; set; }

    public string? Location { get; set; }

    public long? ServiceId { get; set; }

    public int? ServiceDuration { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
