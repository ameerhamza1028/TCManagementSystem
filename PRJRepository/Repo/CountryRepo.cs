using AutoMapper;
using PRJRepository.DTO.Client;
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
        public List<GetAllCountryResponseDTO> GetAllCountry()
        {
            List<GetAllCountryResponseDTO> response = new List<GetAllCountryResponseDTO>();
            List<Models.Country> list = _context.Countries.ToList();
            response = _mapper.Map<List<GetAllCountryResponseDTO>>(list);
            return response;
        }

        public List<GetAllCountryResponseDTO> GetAllRegion(short CountryId)
        {
            List<GetAllCountryResponseDTO> response = new List<GetAllCountryResponseDTO>();
            List<Region> list = _context.Regions.Where(x => x.CountryId == CountryId).ToList();
            response = _mapper.Map<List<GetAllCountryResponseDTO>>(list);
            return response;
        }

        public List<GetAllCountryResponseDTO> GetAllCity(int RegionId)
        {
            List<GetAllCountryResponseDTO> response = new List<GetAllCountryResponseDTO>();
            List<City> list = _context.Cities.Where(x => x.RegionId == RegionId).ToList();
            response = _mapper.Map<List<GetAllCountryResponseDTO>>(list);
            return response;
        }
    }
}
