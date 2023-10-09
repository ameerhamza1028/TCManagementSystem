using System;
using System.Collections.Generic;

namespace PRJRepository.EntityModel;

public partial class Organization
{
    public int OrgId { get; set; }

    public string? OrgName { get; set; }

    public string? OrgAddress { get; set; }

    public string? OrgDescription { get; set; }

    public virtual ICollection<Clinic> Clinics { get; set; } = new List<Clinic>();
}
