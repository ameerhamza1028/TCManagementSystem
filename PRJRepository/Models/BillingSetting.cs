using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class BillingSetting
{
    public int BillingId { get; set; }

    public int? BillingCurrencyId { get; set; }

    public long? TaxId { get; set; }

    public long? OrgNpi { get; set; }

    public int? ServiceDefaultType { get; set; }

    public int? InvoiceCreation { get; set; }

    public int? InvoicePastDue { get; set; }

    public bool? IsGenerateInvoice { get; set; }

    public int? MonthlyStatement { get; set; }

    public int? MonthlySuperbill { get; set; }

    public int? DocumentDelay { get; set; }

    public bool? IsNewClientStatement { get; set; }

    public bool? IsNewClientSuperBills { get; set; }

    public int? DefaultNotification { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
