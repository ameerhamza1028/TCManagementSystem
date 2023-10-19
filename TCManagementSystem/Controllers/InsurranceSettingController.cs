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
    public class InsurranceSettingController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IInsurranceSettingRepo _IInsurranceSettingRepo;

        public InsurranceSettingController(
            IConfiguration config,
            IMapper IMapper,
            IInsurranceSettingRepo IInsurranceSettingRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IInsurranceSettingRepo = IInsurranceSettingRepo;
        }

        [HttpGet]
        [Route("GetAllInsurranceSetting")]
        public ApiResponse<List<GetAllInsurranceSettingResponseDTO>> GetAllUser()
        {
            ApiResponse<List<GetAllInsurranceSettingResponseDTO>> response = new ApiResponse<List<GetAllInsurranceSettingResponseDTO>>();
            try
            {
                List<GetAllInsurranceSettingResponseDTO> result = new List<GetAllInsurranceSettingResponseDTO>();
                result = _IInsurranceSettingRepo.GetAllInsurranceSetting();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetInsurranceSettingById")]
        public ApiResponse<GetAllInsurranceSettingResponseDTO> GetInsurranceSettingById(int id)
        {
            ApiResponse<GetAllInsurranceSettingResponseDTO> response = new ApiResponse<GetAllInsurranceSettingResponseDTO>();
            try
            {
                GetAllInsurranceSettingResponseDTO result = new GetAllInsurranceSettingResponseDTO();
                result = _IInsurranceSettingRepo.GetInsurranceSettingById(id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveInsurranceSetting")]
        public ApiResponse<bool> SaveInsurranceSetting([FromBody] GetAllInsurranceSettingRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IInsurranceSettingRepo.SaveInsurranceSetting(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteInsurranceSetting")]
        public ApiResponse<bool> DeleteInsurranceSetting(int id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IInsurranceSettingRepo.DeleteInsurranceSetting(id);
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
