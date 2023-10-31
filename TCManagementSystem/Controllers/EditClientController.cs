using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Client;
using PRJRepository.DTO.EditClient;
using PRJRepository.Interface;
using PRJRepository.Repo;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditClientController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IEditClientRepo _IEditClientRepo;

        public EditClientController(
            IConfiguration config,
            IMapper IMapper,
            IEditClientRepo IEditClientRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IEditClientRepo = IEditClientRepo;
        }

        [HttpPost]
        [Route("SaveEditClient")]
        public ApiResponse<bool> SaveEditClient([FromBody] SaveEditClientRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IEditClientRepo.SaveClient(request);
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
