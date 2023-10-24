﻿using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class CalenderSetting
{
    public int CalenderId { get; set; }

    public bool? IsOnlineAppointment { get; set; }

    public int? DisplayStartTime { get; set; }

    public TimeSpan? BeforeStartTime { get; set; }

    public TimeSpan? AdvanceTime { get; set; }

    public bool? IsRequestAppointment { get; set; }

    public bool? IsNewIndividualClient { get; set; }

    public bool? IsNewCoupleClient { get; set; }

    public bool? IsNewContacts { get; set; }

    public bool? IsCreditCardRequried { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
