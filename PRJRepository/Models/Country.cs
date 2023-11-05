﻿using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Country
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Language { get; set; } = null!;

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
