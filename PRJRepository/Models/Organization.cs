using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Organization
{
    public long OrgId { get; set; }

    public string? OrgName { get; set; }

    public string? OrgAddress { get; set; }

    public string? OrgLogo { get; set; }

    public string? OrgDescription { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }
}
