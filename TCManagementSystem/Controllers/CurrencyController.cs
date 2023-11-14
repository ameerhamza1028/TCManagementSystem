using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Currency;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly ICurrencyRepo _ICurrencyRepo;

        public CurrencyController(
            IConfiguration config,
            IMapper IMapper,
            ICurrencyRepo ICurrencyRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _ICurrencyRepo = ICurrencyRepo;
        }

        [HttpGet]
        [Route("GetAllCurrency")]
        public ApiResponse<List<GetAllCurrencyResponseDTO>> GetAllCurrency()
        {
            ApiResponse<List<GetAllCurrencyResponseDTO>> response = new ApiResponse<List<GetAllCurrencyResponseDTO>>();
            try
            {
                List<GetAllCurrencyResponseDTO> result = new List<GetAllCurrencyResponseDTO>();
                result = _ICurrencyRepo.GetAllCurrency();
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
