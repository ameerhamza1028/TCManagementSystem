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
        public List<GetAllCountryResponseDTO> GetAllCountry();
        public List<GetAllCountryResponseDTO> GetAllRegion(short CountryId);
        public List<GetAllCountryResponseDTO> GetAllCity(int StateId);
    }
}
