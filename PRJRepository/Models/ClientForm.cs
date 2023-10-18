using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class ClientForm
{
    public long FormId { get; set; }

    public long? ClientId { get; set; }

    public string? FormJson { get; set; }

    public long? FormNumber { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }
}
