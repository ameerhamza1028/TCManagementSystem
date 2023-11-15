using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.CPTCode;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPTCodeController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly ICPTCodeRepo _ICPTCodeRepo;

        public CPTCodeController(
            IConfiguration config,
            IMapper IMapper,
            ICPTCodeRepo ICPTCodeRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _ICPTCodeRepo = ICPTCodeRepo;
        }

        [HttpGet]
        [Route("GetAllCPTCode")]
        public ApiResponse<List<GetAllCPTCodeResponseDTO>> GetAllCPTCode()
        {
            ApiResponse<List<GetAllCPTCodeResponseDTO>> response = new ApiResponse<List<GetAllCPTCodeResponseDTO>>();
            try
            {
                List<GetAllCPTCodeResponseDTO> result = new List<GetAllCPTCodeResponseDTO>();
                result = _ICPTCodeRepo.GetAllCPTCode();
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
