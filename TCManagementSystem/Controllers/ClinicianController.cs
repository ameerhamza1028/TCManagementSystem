using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Clinician;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicianController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IClinicianRepo _IClinicianRepo;

        public ClinicianController(
            IConfiguration config,
            IMapper IMapper,
            IClinicianRepo IClinicianRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IClinicianRepo = IClinicianRepo;
        }

        [HttpGet]
        [Route("GetAllClinician")]
        public ApiResponse<List<GetAllClinicianResponseDTO>> GetAllClinician()
        {
            ApiResponse<List<GetAllClinicianResponseDTO>> response = new ApiResponse<List<GetAllClinicianResponseDTO>>();
            try
            {
                List<GetAllClinicianResponseDTO> result = new List<GetAllClinicianResponseDTO>();
                result = _IClinicianRepo.GetAllClinician();
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
