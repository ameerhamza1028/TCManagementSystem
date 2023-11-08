using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Service
{
    public long? ClientId { get; set; }

    public long ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public int? ServiceDuration { get; set; }

    public decimal? RatePerUnit { get; set; }

    public string? Modifier1 { get; set; }

    public string? Modifier2 { get; set; }

    public string? Modifier3 { get; set; }

    public string? Modifier4 { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public bool? IsActive { get; set; }
}
