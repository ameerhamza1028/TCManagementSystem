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

        [HttpGet]
        [Route("GetEditClientById")]
        public ApiResponse<EditClientResponseDTO> GetClientById(long Id)
        {
            ApiResponse<EditClientResponseDTO> response = new ApiResponse<EditClientResponseDTO>();
            try
            {
                EditClientResponseDTO result = new EditClientResponseDTO();
                result = _IEditClientRepo.GetEditClient(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetEditClientContactById")]
        public ApiResponse<SaveEditClientContactResponseDTO> GetEditClientContactById(long Id)
        {
            ApiResponse<SaveEditClientContactResponseDTO> response = new ApiResponse<SaveEditClientContactResponseDTO>();
            try
            {
                SaveEditClientContactResponseDTO result = new SaveEditClientContactResponseDTO();
                result = _IEditClientRepo.GetEditClientContact(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetEditClientBillingById")]
        public ApiResponse<SaveEditClientBillingResponseDTO> GetEditClientBillingById(long Id)
        {
            ApiResponse<SaveEditClientBillingResponseDTO> response = new ApiResponse<SaveEditClientBillingResponseDTO>();
            try
            {
                SaveEditClientBillingResponseDTO result = new SaveEditClientBillingResponseDTO();
                result = _IEditClientRepo.GetEditClientBilling(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
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

        [HttpPost]
        [Route("SaveEditClientContact")]
        public ApiResponse<bool> SaveEditContactClient([FromBody] SaveEditClientContactRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IEditClientRepo.SaveClientContact(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpPost]
        [Route("SaveEditClientBilling")]
        public ApiResponse<bool> SaveEditBillingClient([FromBody] SaveEditClientBillingRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IEditClientRepo.SaveClientBilling(request);
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
