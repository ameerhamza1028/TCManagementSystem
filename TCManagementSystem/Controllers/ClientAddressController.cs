using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.ClientAddress;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAddressController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IClientAddressRepo _IClientAddressRepo;

        public ClientAddressController(
            IConfiguration config,
            IMapper IMapper,
            IClientAddressRepo IClientAddressRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IClientAddressRepo = IClientAddressRepo;
        }

        [HttpGet]
        [Route("GetAllClientAddresss")]
        public ApiResponse<List<GetAllClientAddressResponseDTO>> GetAllClientAddress(long Id)
        {
            ApiResponse<List<GetAllClientAddressResponseDTO>> response = new ApiResponse<List<GetAllClientAddressResponseDTO>>();
            try
            {
                List<GetAllClientAddressResponseDTO> result = new List<GetAllClientAddressResponseDTO>();
                result = _IClientAddressRepo.GetAllClientAddress(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteClientAddress")]
        public ApiResponse<bool> DeleteClientAddress(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IClientAddressRepo.DeleteClientAddress(Id);
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
