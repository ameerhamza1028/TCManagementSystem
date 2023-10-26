using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Appointment
{
    public long AppointmentId { get; set; }

    public long ClientId { get; set; }

    public string? ClientName { get; set; }

    public bool? IsClientAppointment { get; set; }

    public bool? IsOther { get; set; }

    public bool? AllDay { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }

    public int? Duration { get; set; }

    public long? ClicianId { get; set; }

    public long? LocationId { get; set; }

    public bool? Repeat { get; set; }

    public long? VirtualLocationId { get; set; }

    public int? ServiceId { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
