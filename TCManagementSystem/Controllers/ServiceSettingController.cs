using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.ServiceSetting;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceSettingController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IServiceSettingRepo _IServiceSettingRepo;

        public ServiceSettingController(
            IConfiguration config,
            IMapper IMapper,
            IServiceSettingRepo IServiceSettingRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IServiceSettingRepo = IServiceSettingRepo;
        }

        [HttpGet]
        [Route("GetAllServiceNames")]

        public ApiResponse<List<GetAllServiceResponseDTO>> GetAllServiceNames()
        {
            ApiResponse<List<GetAllServiceResponseDTO>> response = new ApiResponse<List<GetAllServiceResponseDTO>>();
            try
            {
                List<GetAllServiceResponseDTO> result = new List<GetAllServiceResponseDTO>();
                result = _IServiceSettingRepo.GetAllServiceNames();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetAllServiceSetting")]

        public ApiResponse<List<GetAllServiceSettingResponseDTO>> GetAllServicesSetting(long Id)
        {
            ApiResponse<List<GetAllServiceSettingResponseDTO>> response = new ApiResponse<List<GetAllServiceSettingResponseDTO>>();
            try
            {
                List<GetAllServiceSettingResponseDTO> result = new List<GetAllServiceSettingResponseDTO>();
                result = _IServiceSettingRepo.GetAllServiceSetting(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetServiceSettingById")]
        public ApiResponse<EditServiceSettingResponseDTO> GetServiceSettingById(long Id)
        {
            ApiResponse<EditServiceSettingResponseDTO> response = new ApiResponse<EditServiceSettingResponseDTO>();
            try
            {
                EditServiceSettingResponseDTO result = new EditServiceSettingResponseDTO();

                result = _IServiceSettingRepo.GetServiceSettingById(Id);

                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveServiceSetting")]
        public ApiResponse<bool> SaveServiceSetting([FromBody] GetAllServiceSettingRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IServiceSettingRepo.SaveServiceSetting(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteServiceSetting")]

        public ApiResponse<bool> DeleteServiceSetting(long Id)

        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {

                _IServiceSettingRepo.DeleteServiceSetting(Id);

                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetClinicianServices")]

        public ApiResponse<List<GetAllClinicianServiceResponseDTO>> GetClinicianServices(long Id)
        {
            ApiResponse<List<GetAllClinicianServiceResponseDTO>> response = new ApiResponse<List<GetAllClinicianServiceResponseDTO>>();
            try
            {
                List<GetAllClinicianServiceResponseDTO> result = new List<GetAllClinicianServiceResponseDTO>();
                result = _IServiceSettingRepo.GetClinicianServices(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
