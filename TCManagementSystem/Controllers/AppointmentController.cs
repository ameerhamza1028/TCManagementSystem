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
    public class AppointmentController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IAppointmentRepo _IAppointmentRepo;

        public AppointmentController(
            IConfiguration config,
            IMapper IMapper,
            IAppointmentRepo IAppointmentRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IAppointmentRepo = IAppointmentRepo;
        }

        [HttpGet]
        [Route("GetAllAppointment")]
        public ApiResponse<List<GetAllAppointmentResponseDTO>> GetAllUser()
        {
            ApiResponse<List<GetAllAppointmentResponseDTO>> response = new ApiResponse<List<GetAllAppointmentResponseDTO>>();
            try
            {
                List<GetAllAppointmentResponseDTO> result = new List<GetAllAppointmentResponseDTO>();
                result = _IAppointmentRepo.GetAllAppointment();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetAppointmentById")]
        public ApiResponse<GetAllAppointmentResponseDTO> GetClinicById(int id)
        {
            ApiResponse<GetAllAppointmentResponseDTO> response = new ApiResponse<GetAllAppointmentResponseDTO>();
            try
            {
                GetAllAppointmentResponseDTO result = new GetAllAppointmentResponseDTO();
                result = _IAppointmentRepo.GetAppointmentById(id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveClinic")]
        public ApiResponse<bool> SaveClinic([FromBody] GetAllAppointmentRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IAppointmentRepo.SaveAppointment(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteClinic")]
        public ApiResponse<bool> DeleteClinic(int id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IAppointmentRepo.DeleteAppointment(id);
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
