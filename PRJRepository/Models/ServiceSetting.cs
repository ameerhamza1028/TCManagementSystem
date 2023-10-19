using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class ServiceSetting
{
<<<<<<< HEAD
    public long ServiceId { get; set; }
=======
    public int ServiceId { get; set; }
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40

    public string? ServiceName { get; set; }

    public string? ServiceDescription { get; set; }

    public long? Cptcode { get; set; }

    public int? RatePerUnit { get; set; }

    public int? Duration { get; set; }

    public bool? IsDefaultService { get; set; }

    public bool? IsSelfPay { get; set; }

    public bool? IsBookedforNewClient { get; set; }

    public bool? IsBookedforCurrentClient { get; set; }

    public int? MinutesBefore { get; set; }

    public int? MinutesAfter { get; set; }

    public int? ClicianId { get; set; }
<<<<<<< HEAD

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
=======
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
}
