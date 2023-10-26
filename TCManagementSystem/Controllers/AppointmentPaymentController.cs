using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.AppointmentPayment;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentPaymentController : ControllerBase
    {
            public IConfiguration _configuration;
            private readonly IMapper _mapper;

            private readonly IAppointmentPaymentRepo _IAppointmentPaymentRepo;

            public AppointmentPaymentController(
                IConfiguration config,
                IMapper IMapper,
                IAppointmentPaymentRepo IAppointmentPaymentRepo)
            {
                _configuration = config;
                _mapper = IMapper;
                _IAppointmentPaymentRepo = IAppointmentPaymentRepo;
            }

            [HttpGet]
            [Route("GetAllAppointmentPayment")]
            public ApiResponse<List<GetAllAppointmentPaymentResponseDTO>> GetAllAppointmentPayment()
            {
                ApiResponse<List<GetAllAppointmentPaymentResponseDTO>> response = new ApiResponse<List<GetAllAppointmentPaymentResponseDTO>>();
                try
                {
                    List<GetAllAppointmentPaymentResponseDTO> result = new List<GetAllAppointmentPaymentResponseDTO>();
                    result = _IAppointmentPaymentRepo.GetAllAppointmentPayment();
                    response.Data = result;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpGet]
            [Route("GetAppointmentPaymentById")]
            public ApiResponse<GetAllAppointmentPaymentResponseDTO> GetAppointmentPaymentById(long Id)
            {
                ApiResponse<GetAllAppointmentPaymentResponseDTO> response = new ApiResponse<GetAllAppointmentPaymentResponseDTO>();
                try
                {
                    GetAllAppointmentPaymentResponseDTO result = new GetAllAppointmentPaymentResponseDTO();
                    result = _IAppointmentPaymentRepo.GetAppointmentPaymentById(Id);
                    response.Data = result;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpPost]
            [Route("SaveAppointmentPayment")]
            public ApiResponse<bool> SaveAppointmentPayment([FromBody] GetAllAppointmentPaymentRequestDTO request)
            {
                ApiResponse<bool> response = new ApiResponse<bool>();
                try
                {
                    _IAppointmentPaymentRepo.SaveAppointmentPayment(request);
                    response.Data = true;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpDelete]
            [Route("DeleteAppointmentPayment")]
            public ApiResponse<bool> DeleteAppointmentPayment(long Id)
            {
                ApiResponse<bool> response = new ApiResponse<bool>();
                try
                {
                    _IAppointmentPaymentRepo.DeleteAppointmentPayment(Id);
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
