﻿using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Address
{
    public long AddressId { get; set; }

    public string? Address1 { get; set; }

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public long? ZipCode { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public bool? IsActive { get; set; }
}