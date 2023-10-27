using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Message
{
    public long MessageId { get; set; }

    public long? MessageSenderId { get; set; }

    public long? MessageReceiverId { get; set; }

    public string? Message1 { get; set; }

    public DateTime? CreactionDate { get; set; }

    public bool? IsActive { get; set; }
}
