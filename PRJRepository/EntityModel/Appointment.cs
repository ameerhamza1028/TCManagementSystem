using System;
using System.Collections.Generic;

namespace PRJRepository.EntityModel;

public partial class Appointment
{
    public string? Type { get; set; }

    public int AppointmentId { get; set; }

    public int ClientId { get; set; }

    public bool? AllDay { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }

    public byte[]? Duration { get; set; }

    public long? ClicianId { get; set; }

    public long? LocationId { get; set; }

    public bool? Repeat { get; set; }

    public long? VirtualLocationId { get; set; }

    public int? ServiceId { get; set; }

    public string? Title { get; set; }

    public virtual Tcuser Client { get; set; } = null!;
}
