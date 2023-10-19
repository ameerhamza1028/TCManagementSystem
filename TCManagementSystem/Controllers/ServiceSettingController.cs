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
<<<<<<< HEAD
        public ApiResponse<List<GetAllServiceSettingResponseDTO>> GetAllServicesSetting()
=======
        public ApiResponse<List<GetAllServiceSettingResponseDTO>> GetAllUser()
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
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
<<<<<<< HEAD
        public ApiResponse<GetAllServiceSettingResponseDTO> GetServiceSettingById(long Id)
=======
        public ApiResponse<GetAllServiceSettingResponseDTO> GetServiceSettingById(int id)
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
        {
            ApiResponse<GetAllServiceSettingResponseDTO> response = new ApiResponse<GetAllServiceSettingResponseDTO>();
            try
            {
                GetAllServiceSettingResponseDTO result = new GetAllServiceSettingResponseDTO();
<<<<<<< HEAD
                result = _IServiceSettingRepo.GetServiceSettingById(Id);
=======
                result = _IServiceSettingRepo.GetServiceSettingById(id);
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
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
<<<<<<< HEAD
        public ApiResponse<bool> DeleteServiceSetting(long Id)
=======
        public ApiResponse<bool> DeleteServiceSetting(int id)
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
<<<<<<< HEAD
                _IServiceSettingRepo.DeleteServiceSetting(Id);
=======
                _IServiceSettingRepo.DeleteServiceSetting(id);
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
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
