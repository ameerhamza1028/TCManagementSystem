using System;
using System.Collections.Generic;

namespace PRJRepository.EntityModel;

public partial class AvailableSlot
{
    public long AppointmntSlotId { get; set; }

    public bool? AppointmentRequest { get; set; }

    public string? Name { get; set; }

    public long? ClicianId { get; set; }

    public DateTime? SlotDate { get; set; }

    public TimeSpan? Time { get; set; }

    public TimeSpan? Duration { get; set; }

    public bool? Repeat { get; set; }

    public int? Weeks { get; set; }

    public int? Days { get; set; }

    public bool? Inperson { get; set; }

    public long? InpersonlocationId { get; set; }

    public bool? Telehealth { get; set; }

    public long? LocationId { get; set; }
}
