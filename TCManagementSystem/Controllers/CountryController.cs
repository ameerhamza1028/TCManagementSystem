using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Client;
using PRJRepository.DTO.Clinic;
using PRJRepository.DTO.Country;
using PRJRepository.Interface;
using PRJRepository.Repo;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly ICountryRepo _ICountryRepo;

        public CountryController(
            IConfiguration config,
            IMapper IMapper,
            ICountryRepo ICountryRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _ICountryRepo = ICountryRepo;
        }

        [HttpGet]
        [Route("GetAllCountry")]
        public ApiResponse<List<GetAllCountryResponseDTO>> GetAllCountry()
        {
            ApiResponse<List<GetAllCountryResponseDTO>> response = new ApiResponse<List<GetAllCountryResponseDTO>>();
            try
            {
                List<GetAllCountryResponseDTO> result = new List<GetAllCountryResponseDTO>();
                result = _ICountryRepo.GetAllCountry();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetAllRegionByCountryId")]
        public ApiResponse<List<GetAllCountryResponseDTO>> GetAllRegion(short CountryId)
        {
            ApiResponse<List<GetAllCountryResponseDTO>> response = new ApiResponse<List<GetAllCountryResponseDTO>>();
            try
            {
                List<GetAllCountryResponseDTO> result = new List<GetAllCountryResponseDTO>();
                result = _ICountryRepo.GetAllRegion(CountryId);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetAllCityByRegionId")]
        public ApiResponse<List<GetAllCountryResponseDTO>> GetAllCity(int RegionId)
        {
            ApiResponse<List<GetAllCountryResponseDTO>> response = new ApiResponse<List<GetAllCountryResponseDTO>>();
            try
            {
                List<GetAllCountryResponseDTO> result = new List<GetAllCountryResponseDTO>();
                result = _ICountryRepo.GetAllCity(RegionId);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
