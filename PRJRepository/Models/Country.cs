using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Country
{
    public short Id { get; set; }

    public string ShortName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Phone { get; set; }
}
