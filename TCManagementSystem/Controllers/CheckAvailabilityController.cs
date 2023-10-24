using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.CheckAvailability;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckAvailabilityController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly ICheckAvailabilityRepo _ICheckAvailabilityRepo;

        public CheckAvailabilityController(
            IConfiguration config,
            IMapper IMapper,
            ICheckAvailabilityRepo ICheckAvailabilityRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _ICheckAvailabilityRepo = ICheckAvailabilityRepo;
        }

        [HttpGet]
        [Route("GetCheckAvailability")]
        public ApiResponse<GetAllCheckAvailabilityResponseDTO> GetCheckAvailability(GetAllCheckAvailabilityRequestDTO request
            )
        {
            ApiResponse<GetAllCheckAvailabilityResponseDTO> response = new ApiResponse<GetAllCheckAvailabilityResponseDTO>();
            try
            {
                GetAllCheckAvailabilityResponseDTO result = new GetAllCheckAvailabilityResponseDTO();
                result = _ICheckAvailabilityRepo.GetCheckAvailability(request);
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
