using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.Repo;
using PRJRepository.DTO;
using TCManagementSystem.Helper;

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
        public ApiResponse<List<GetAllResponseDTO>> GetAllClient()
        {
            ApiResponse<List<GetAllResponseDTO>> response = new ApiResponse<List<GetAllResponseDTO>>();
            try
            {
                List<GetAllResponseDTO> result = new List<GetAllResponseDTO>();
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
        public ApiResponse<GetAllResponseDTO> GetClientById(long Id)
        {
            ApiResponse<GetAllResponseDTO> response = new ApiResponse<GetAllResponseDTO>();
            try
            {
                GetAllResponseDTO result = new GetAllResponseDTO();
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
        public ApiResponse<bool> SaveClient([FromBody] GetAllRequestDTO request)
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
