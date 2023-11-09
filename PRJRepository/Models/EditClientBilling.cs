using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class EditClientBilling
{
    public long? ClientId { get; set; }

    public long BillingId { get; set; }

    public string? PaymentPay { get; set; }

    public bool? IsCreateMonthlyStatement { get; set; }

    public bool? IsCreateMonthlySuperBills { get; set; }

    public string? EmailNotification { get; set; }

    public bool? IsNotifyNewInvoice { get; set; }

    public bool? IsNotifyNewStatement { get; set; }

    public bool? IsnotifyNewSuperBills { get; set; }
}
