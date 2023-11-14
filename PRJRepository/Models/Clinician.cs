using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Clinician
{
    public int ClinicianId { get; set; }

    public long? UserId { get; set; }

    public string? ClinicianName { get; set; }

    public long? ServiceId { get; set; }
}
