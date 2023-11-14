using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Service;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IServiceRepo _IServiceRepo;

        public ServiceController(
            IConfiguration config,
            IMapper IMapper,
            IServiceRepo IServiceRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IServiceRepo = IServiceRepo;
        }

        [HttpGet]
        [Route("GetAllServices")]
        public ApiResponse<List<GetAllServiceResponseDTO>> GetAllService(long Id)
        {
            ApiResponse<List<GetAllServiceResponseDTO>> response = new ApiResponse<List<GetAllServiceResponseDTO>>();
            try
            {
                List<GetAllServiceResponseDTO> result = new List<GetAllServiceResponseDTO>();
                result = _IServiceRepo.GetAllService(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteService")]
        public ApiResponse<bool> DeleteService(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IServiceRepo.DeleteService(Id);
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
