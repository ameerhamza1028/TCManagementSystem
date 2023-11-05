using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Country
{
    public class GetCountryByIdRequestDTO
    {
        public int CountryId { get; set; }

        public int RegionId { get; set; }

        public int CityId { get; set; }

    }
}
