using System;
using System.Collections.Generic;

namespace PRJRepository.EntityModel;

public partial class Invoice
{
    public long InvoiveId { get; set; }

    public string? InvoiceType { get; set; }
}
