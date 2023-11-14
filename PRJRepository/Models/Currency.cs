using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Currency
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string Currency1 { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Symbol { get; set; } = null!;
}
