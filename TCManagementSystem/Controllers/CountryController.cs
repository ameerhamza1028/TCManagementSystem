using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Route("GetCountryById")]
        public ApiResponse<GetCountryByIdResponseDTO> GetCountryById(int CountryId,int RegionId, int CityId)
        {
            ApiResponse<GetCountryByIdResponseDTO> response = new ApiResponse<GetCountryByIdResponseDTO>();
            try
            {
                GetCountryByIdResponseDTO result = new GetCountryByIdResponseDTO();
                result = _ICountryRepo.GetCountryById(CountryId,RegionId,CityId);
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
