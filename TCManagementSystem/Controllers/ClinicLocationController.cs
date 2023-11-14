using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.ClinicLocation;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicLocationController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IClinicLocationRepo _IClinicLocationRepo;

        public ClinicLocationController(
            IConfiguration config,
            IMapper IMapper,
            IClinicLocationRepo IClinicLocationRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IClinicLocationRepo = IClinicLocationRepo;
        }

        [HttpGet]
        [Route("GetAllClinicLocation")]
        public ApiResponse<List<GetAllClinicLocationResponseDTO>> GetAllClinicLocation()
        {
            ApiResponse<List<GetAllClinicLocationResponseDTO>> response = new ApiResponse<List<GetAllClinicLocationResponseDTO>>();
            try
            {
                List<GetAllClinicLocationResponseDTO> result = new List<GetAllClinicLocationResponseDTO>();
                result = _IClinicLocationRepo.GetAllClinicLocation();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetClinicLocationById")]
        public ApiResponse<GetAllClinicLocationResponseDTO> GetClinicLocationById(long Id)
        {
            ApiResponse<GetAllClinicLocationResponseDTO> response = new ApiResponse<GetAllClinicLocationResponseDTO>();
            try
            {
                GetAllClinicLocationResponseDTO result = new GetAllClinicLocationResponseDTO();
                result = _IClinicLocationRepo.GetClinicLocationById(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveClinicLocation")]
        public ApiResponse<bool> SaveClinicLocation([FromBody] GetAllClinicLocationRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IClinicLocationRepo.SaveClinicLocation(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteClinicLocation")]
        public ApiResponse<bool> DeleteClinicLocation(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IClinicLocationRepo.DeleteClinicLocation(Id);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
