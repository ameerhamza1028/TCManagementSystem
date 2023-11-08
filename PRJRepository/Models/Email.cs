using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Email
{
    public long? ClientId { get; set; }

    public long EmailId { get; set; }

    public string? EmailAddress { get; set; }

    public string? EmailType { get; set; }

    public bool? IsEmailOk { get; set; }

    public bool? IsAccessToClientPortal { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public bool? IsActive { get; set; }
}
