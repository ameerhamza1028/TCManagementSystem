using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO;
using PRJRepository.Repo;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientFormController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IClientFormRepo _IClientFormRepo;

        public ClientFormController(
            IConfiguration config,
            IMapper IMapper,
            IClientFormRepo IClientFormRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IClientFormRepo = IClientFormRepo;
        }

        [HttpGet]
        [Route("GetClientFormById")]
        public ApiResponse<GetAllClientFormResponseDTO> GetClientFormById(long Id)
        {
            ApiResponse<GetAllClientFormResponseDTO> response = new ApiResponse<GetAllClientFormResponseDTO>();
            try
            {
                GetAllClientFormResponseDTO result = new GetAllClientFormResponseDTO();
                result = _IClientFormRepo.GetClientFormById(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveClientForm")]
        public ApiResponse<bool> SaveClientForm([FromBody] GetAllClientFormRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IClientFormRepo.SaveClientForm(request);
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
