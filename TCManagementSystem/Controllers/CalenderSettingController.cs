using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.CalenderSetting;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalenderSettingController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly ICalenderSettingRepo _ICalenderSettingRepo;

        public CalenderSettingController(
            IConfiguration config,
            IMapper IMapper,
            ICalenderSettingRepo ICalenderSettingRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _ICalenderSettingRepo = ICalenderSettingRepo;
        }

        [HttpGet]
        [Route("GetAllCalenderSetting")]

        public ApiResponse<List<GetAllCalenderSettingResponseDTO>> GetAllCalenderSetting()
        {
            ApiResponse<List<GetAllCalenderSettingResponseDTO>> response = new ApiResponse<List<GetAllCalenderSettingResponseDTO>>();
            try
            {
                List<GetAllCalenderSettingResponseDTO> result = new List<GetAllCalenderSettingResponseDTO>();
                result = _ICalenderSettingRepo.GetAllCalenderSetting();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetCalenderSettingById")]

        public ApiResponse<GetAllCalenderSettingResponseDTO> GetCalenderSettingById(long Id)
        {
            ApiResponse<GetAllCalenderSettingResponseDTO> response = new ApiResponse<GetAllCalenderSettingResponseDTO>();
            try
            {
                GetAllCalenderSettingResponseDTO result = new GetAllCalenderSettingResponseDTO();

                result = _ICalenderSettingRepo.GetCalenderSettingById(Id);

                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveCalenderSetting")]
        public ApiResponse<bool> SaveCalenderSetting([FromBody] GetAllCalenderSettingRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _ICalenderSettingRepo.SaveCalenderSetting(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteCalenderSetting")]

        public ApiResponse<bool> DeleteCalenderSetting(long Id)

        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {

                _ICalenderSettingRepo.DeleteCalenderSetting(Id);

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
