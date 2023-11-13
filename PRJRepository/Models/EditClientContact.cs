using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class EditClientContact
{
    public long? ClientId { get; set; }

    public long ContactId { get; set; }

    public string? ContactFirstName { get; set; }

    public string? ContactMiddleName { get; set; }

    public string? ContactLastName { get; set; }

    public string? ContactSuffix { get; set; }

    public string? ContactNameGoBy { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactEmailType { get; set; }

    public string? ContactRelationshipStatus { get; set; }

    public bool? IsAccessToClientPortal { get; set; }

    public bool? IsEmergencyContact { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
