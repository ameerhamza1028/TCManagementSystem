using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class CheckAvaliability
{
    public long CheckAvailabilityId { get; set; }

    public int? Duration { get; set; }

    public long? ClinicianId { get; set; }

    public int? LocationId { get; set; }

    public DateTime? SelectDate { get; set; }

    public bool? InsurranceAccept { get; set; }
}
