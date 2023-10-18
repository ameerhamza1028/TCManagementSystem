using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class InsurranceSetting
{
    public long InsurranceId { get; set; }

    public bool? IsIndividual { get; set; }

    public bool? IsOrganization { get; set; }

    public bool? IsPracticeDefault { get; set; }

    public string? PracticeName { get; set; }

    public string? Address { get; set; }

    public string? Street { get; set; }

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public long? Zip { get; set; }

    public long? Npi { get; set; }

    public long? Taxonomy { get; set; }

    public bool? IsClaimForm { get; set; }

    public bool? IsMultipleDiagnosisCode { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
