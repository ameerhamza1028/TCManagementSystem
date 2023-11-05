using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCManagementSystem.Helper;
using PRJRepository.DTO.Client;
using PRJRepository.Interface;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IClientRepo _IClientRepo;

        public ClientController(
            IConfiguration config,
            IMapper IMapper,
            IClientRepo IClientRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IClientRepo = IClientRepo;
        }

        [HttpGet]
        [Route("GetAllClients")]
        public ApiResponse<List<GetAllClientResponseDTO>> GetAllClient()
        {
            ApiResponse<List<GetAllClientResponseDTO>> response = new ApiResponse<List<GetAllClientResponseDTO>>();
            try
            {
                List<GetAllClientResponseDTO> result = new List<GetAllClientResponseDTO>();
                result = _IClientRepo.GetAllClient();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpGet]
        [Route("GetClientById")]
        public ApiResponse<EditClientResponseDTO> GetClientById(long Id)
        {
            ApiResponse<EditClientResponseDTO> response = new ApiResponse<EditClientResponseDTO>();
            try
            {
                EditClientResponseDTO result = new EditClientResponseDTO();
                result = _IClientRepo.GetClientById(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveClient")]
        public ApiResponse<bool> SaveClient([FromBody] GetAllClientRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IClientRepo.SaveClient(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteClient")]
        public ApiResponse<bool> DeleteClient(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IClientRepo.DeleteClient(Id);
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
