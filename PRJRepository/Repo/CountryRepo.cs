using AutoMapper;
using PRJRepository.DTO.Clinic;
using PRJRepository.DTO.Country;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class CountryRepo : ICountryRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public CountryRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetCountryByIdResponseDTO GetCountryById(int CountryId, int RegionId, int CityId)
        {
            GetCountryByIdResponseDTO response = new GetCountryByIdResponseDTO();
            Country country = _context.Countries.Where(x => x.Id == CountryId).FirstOrDefault();
            if(country != null)
            {
                Region region = _context.Regions.Where(x => x.CountryId == CountryId && x.Id == RegionId).FirstOrDefault();
                if(region != null)
                {
                    City city = _context.Cities.Where(x => x.RegionId == RegionId && x.Id == CityId).FirstOrDefault();
                    if(city != null)
                    {
                        response.CountryName = _context.Countries.Where(x => x.Id == CountryId).Select(x => x.Name).FirstOrDefault();
                        response.RegionName = _context.Regions.Where(x => x.Id == RegionId).Select(x => x.Name).FirstOrDefault();
                        response.CityName = _context.Cities.Where(x => x.Id == CityId).Select(x => x.Name).FirstOrDefault();
                    }
                }
            }
            
            return response;
        }
    }
}
