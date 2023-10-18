using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Invoice
{
    public long InvoiveId { get; set; }

    public string? InvoiceType { get; set; }
}
