using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class CheckAvaliability
{
    public long CheckAvailabilityId { get; set; }

    public int? Duration { get; set; }

    public long? ClinicianId { get; set; }

    public string? Location { get; set; }

    public DateTime? SelectDate { get; set; }

    public int? InsurranceAccept { get; set; }
}
