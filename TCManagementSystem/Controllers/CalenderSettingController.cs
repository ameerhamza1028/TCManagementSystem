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
<<<<<<< HEAD
        public ApiResponse<List<GetAllCalenderSettingResponseDTO>> GetAllCalenderSetting()
=======
        public ApiResponse<List<GetAllCalenderSettingResponseDTO>> GetAllUser()
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
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
<<<<<<< HEAD
        public ApiResponse<GetAllCalenderSettingResponseDTO> GetCalenderSettingById(long Id)
=======
        public ApiResponse<GetAllCalenderSettingResponseDTO> GetCalenderSettingById(int id)
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
        {
            ApiResponse<GetAllCalenderSettingResponseDTO> response = new ApiResponse<GetAllCalenderSettingResponseDTO>();
            try
            {
                GetAllCalenderSettingResponseDTO result = new GetAllCalenderSettingResponseDTO();
<<<<<<< HEAD
                result = _ICalenderSettingRepo.GetCalenderSettingById(Id);
=======
                result = _ICalenderSettingRepo.GetCalenderSettingById(id);
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
<<<<<<< HEAD
        public ApiResponse<bool> DeleteCalenderSetting(long Id)
=======
        public ApiResponse<bool> DeleteCalenderSetting(int id)
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
<<<<<<< HEAD
                _ICalenderSettingRepo.DeleteCalenderSetting(Id);
=======
                _ICalenderSettingRepo.DeleteCalenderSetting(id);
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
