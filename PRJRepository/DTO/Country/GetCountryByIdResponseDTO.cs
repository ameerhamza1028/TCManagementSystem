using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Country
{
    public class GetCountryByIdResponseDTO
    {
        public string? CountryName { get; set; }
        public string? RegionName { get; set; }
        public string? CityName { get; set; }

    }
}
