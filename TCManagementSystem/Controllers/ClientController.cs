using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCManagementSystem.Helper;
using PRJRepository.DTO.Client;
using PRJRepository.Interface;
using PRJRepository.DTO.EditClient;

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
        [Route("GetAllClientsNames")]
        public ApiResponse<List<GetAllClientNameResponseDTO>> GetAllClientName()
        {
            ApiResponse<List<GetAllClientNameResponseDTO>> response = new ApiResponse<List<GetAllClientNameResponseDTO>>();
            try
            {
                List<GetAllClientNameResponseDTO> result = new List<GetAllClientNameResponseDTO>();
                result = _IClientRepo.GetAllClientNames();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetAllClients")]
        public ApiResponse<List<SaveEditClientResponseDTO>> GetAllClient()
        {
            ApiResponse<List<SaveEditClientResponseDTO>> response = new ApiResponse<List<SaveEditClientResponseDTO>>();
            try
            {
                List<SaveEditClientResponseDTO> result = new List<SaveEditClientResponseDTO>();
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

        [HttpPost]
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
