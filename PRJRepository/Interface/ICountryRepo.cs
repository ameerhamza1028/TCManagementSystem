using PRJRepository.DTO.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface ICountryRepo
    {
        public GetCountryByIdResponseDTO GetCountryById(int CountryId, int RegionId, int CityId);
    }
}
