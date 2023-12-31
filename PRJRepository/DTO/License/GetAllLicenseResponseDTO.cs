﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.License
{
    public class GetAllLicenseResponseDTO
    {
        public long LicenseId { get; set; }

        public string? LicenseType { get; set; }

        public long? LicenseNumber { get; set; }

        public DateTime? LicenseExpirationDate { get; set; }

        public string? LicenseState { get; set; }

    }
}
