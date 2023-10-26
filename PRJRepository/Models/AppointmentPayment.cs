using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class AppointmentPayment
{
    public long AppointmentPaymentId { get; set; }

    public string? ClientName { get; set; }

    public long? Cptcode { get; set; }

    public decimal? Billed { get; set; }

    public decimal? ClientOwes { get; set; }

    public decimal? InsurancePaid { get; set; }

    public decimal? WriteOff { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? Createdby { get; set; }

    public bool? IsActive { get; set; }
}
