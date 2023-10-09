using System;
using System.Collections.Generic;

namespace PRJRepository.EntityModel;

public partial class ClinicLocation
{
    public int LocationId { get; set; }

    public string? ShortName { get; set; }

    public string? LongName { get; set; }

    public string? Address { get; set; }

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public string? ZipCode { get; set; }

    public string? BillingAddress { get; set; }

    public string? IndividualOffice { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public long? TaxId { get; set; }

    public long? Npi { get; set; }

    public long? Taxonomy { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int? ServicePlace { get; set; }

    public bool? IsActive { get; set; }
}
