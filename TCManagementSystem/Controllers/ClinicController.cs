using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Clinic;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IClinicRepo _IClinicRepo;

        public ClinicController(
            IConfiguration config,
            IMapper IMapper,
            IClinicRepo IClinicRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IClinicRepo = IClinicRepo;
        }

        [HttpGet]
        [Route("GetAllClinic")]
        public ApiResponse<List<GetAllClinicResponseDTO>> GetAllClinic()
        {
            ApiResponse<List<GetAllClinicResponseDTO>> response = new ApiResponse<List<GetAllClinicResponseDTO>>();
            try
            {
                List<GetAllClinicResponseDTO> result = new List<GetAllClinicResponseDTO>();
                result = _IClinicRepo.GetAllClinic();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetClinicById")]
        public ApiResponse<EditClinicResponseDTO> GetClinicById(long Id)
        {
            ApiResponse<EditClinicResponseDTO> response = new ApiResponse<EditClinicResponseDTO>();
            try
            {
                EditClinicResponseDTO result = new EditClinicResponseDTO();
                result = _IClinicRepo.GetClinicById(Id);
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
        public ApiResponse<bool> SaveClinic([FromBody] GetAllClinicRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IClinicRepo.SaveClinic(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteClinic")]
        public ApiResponse<bool> DeleteClinic(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IClinicRepo.DeleteClinic(Id);
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
