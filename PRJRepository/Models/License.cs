using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class License
{
    public long? UserId { get; set; }

    public long LicenseId { get; set; }

    public string? LicenseType { get; set; }

    public long? LicenseNumber { get; set; }

    public DateTime? LicenseExpirationDate { get; set; }

    public string? LicenseState { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }
}
