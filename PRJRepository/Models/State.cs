using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class State
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public short CountryId { get; set; }
}
