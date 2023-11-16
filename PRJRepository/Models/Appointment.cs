using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Appointment
{
    public long AppointmentId { get; set; }

    public long ClientId { get; set; }

    public int? AppointmentType { get; set; }

    public bool? AllDay { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }

    public int? Duration { get; set; }

    public long? ClicianId { get; set; }

    public string? Location { get; set; }

    public bool? IsRepeat { get; set; }

    public string? VirtualLocationId { get; set; }

    public long? ServiceId { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
