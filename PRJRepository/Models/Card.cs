using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Card
{
    public long CardId { get; set; }

    public long? CardNumber { get; set; }

    public DateTime? DateExpire { get; set; }

    public string? CardType { get; set; }

    public bool? IsSetDefault { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public bool? IsActive { get; set; }
}
