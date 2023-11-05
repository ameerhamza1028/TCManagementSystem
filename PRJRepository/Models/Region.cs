﻿using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Region
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public short CountryId { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country Country { get; set; } = null!;
}
