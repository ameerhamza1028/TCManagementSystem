using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Phone
{
    public long? ClientId { get; set; }

    public long PhoneId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? PhoneType { get; set; }

    public bool? IsSendTextMessage { get; set; }

    public bool? IsSendVoiceMessage { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreactionDate { get; set; }

    public bool? IsActive { get; set; }

    public long? ContactId { get; set; }

    public int? CouplePhoneId { get; set; }
}
