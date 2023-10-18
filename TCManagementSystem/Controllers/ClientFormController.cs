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

        private readonly IClientFormRepo _IPatientFormRepo;

        public ClientFormController(
            IConfiguration config,
            IMapper IMapper,
            IClientFormRepo IPatientFormRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IPatientFormRepo = IPatientFormRepo;
        }

        [HttpGet]
        [Route("GetPatientFormById")]
        public ApiResponse<GetAllClientFormResponseDTO> GetPatientFormById(long Id)
        {
            ApiResponse<GetAllClientFormResponseDTO> response = new ApiResponse<GetAllClientFormResponseDTO>();
            try
            {
                GetAllClientFormResponseDTO result = new GetAllClientFormResponseDTO();
                result = _IPatientFormRepo.GetClientFormById(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SavePatientForm")]
        public ApiResponse<bool> SavePatientForm([FromBody] GetAllClientFormRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IPatientFormRepo.SaveClientForm(request);
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
