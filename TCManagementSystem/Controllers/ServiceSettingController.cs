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
        [Route("GetAllServiceSetting")]

        public ApiResponse<List<GetAllServiceSettingResponseDTO>> GetAllServicesSetting()
        {
            ApiResponse<List<GetAllServiceSettingResponseDTO>> response = new ApiResponse<List<GetAllServiceSettingResponseDTO>>();
            try
            {
                List<GetAllServiceSettingResponseDTO> result = new List<GetAllServiceSettingResponseDTO>();
                result = _IServiceSettingRepo.GetAllServiceSetting();
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
        public ApiResponse<GetAllServiceSettingResponseDTO> GetServiceSettingById(long Id)
        {
            ApiResponse<GetAllServiceSettingResponseDTO> response = new ApiResponse<GetAllServiceSettingResponseDTO>();
            try
            {
                GetAllServiceSettingResponseDTO result = new GetAllServiceSettingResponseDTO();

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

        [HttpDelete]
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
    }
}
