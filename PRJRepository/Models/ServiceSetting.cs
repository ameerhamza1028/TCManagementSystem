﻿using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class ServiceSetting
{
    public long? ClinicId { get; set; }

    public long ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public string? ServiceDescription { get; set; }

    public int? Cptcode { get; set; }

    public int? RatePerUnit { get; set; }

    public int? Duration { get; set; }

    public bool? IsDefaultService { get; set; }

    public int? PaymentType { get; set; }

    public bool? IsBookedforNewClient { get; set; }

    public bool? IsBookedforCurrentClient { get; set; }

    public int? MinutesBefore { get; set; }

    public int? MinutesAfter { get; set; }

    public string? ClinicianId { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
