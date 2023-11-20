using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class ClinicianService
{
    public int ClinicianServiceId { get; set; }

    public int? ClinicianId { get; set; }

    public string? ClinicianName { get; set; }

    public long? ServiceId { get; set; }

    public bool? IsActive { get; set; }
}
