﻿using PRJRepository.DTO.License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface ILicenseRepo
    {
        public List<GetAllLicenseResponseDTO> GetAllLicense();
        public bool SaveLicense(GetAllLicenseRequestDTO request);
        public bool DeleteLicense(long Id);
    }
}