using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class PatientForm
{
    public long FormId { get; set; }

    public long? ClientId { get; set; }

    public string? FormJson { get; set; }

    public long? FormNumber { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }
}
