using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Address
{
    public long? ClientId { get; set; }

    public long AddressId { get; set; }

    public string? Address1 { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public string? ZipCode { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public bool? IsActive { get; set; }
}
