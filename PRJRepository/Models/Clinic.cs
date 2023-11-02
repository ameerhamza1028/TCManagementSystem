using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Clinic
{
    public long ClinicId { get; set; }

    public string? LongFacilityName { get; set; }

    public string? ShortFacilityName { get; set; }

    public string? Address { get; set; }

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public string? ZipCode { get; set; }

    public string? BillingAddress { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public long? TaxId { get; set; }

    public long? Npi { get; set; }

    public long? Taxomony { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public long? ServicePlaceId { get; set; }

    public bool? Message { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }
}
