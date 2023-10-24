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
    public class LicenseController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly ILicenseRepo _ILicenseRepo;

        public LicenseController(
            IConfiguration config,
            IMapper IMapper,
            ILicenseRepo ILicenseRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _ILicenseRepo = ILicenseRepo;
        }

        [HttpGet]
        [Route("GetAllLicense")]
        public ApiResponse<List<GetAllLicenseResponseDTO>> GetAllLicense()
        {
            ApiResponse<List<GetAllLicenseResponseDTO>> response = new ApiResponse<List<GetAllLicenseResponseDTO>>();
            try
            {
                List<GetAllLicenseResponseDTO> result = new List<GetAllLicenseResponseDTO>();
                result = _ILicenseRepo.GetAllLicense();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveLicense")]
        public ApiResponse<bool> SaveLicense([FromBody] GetAllLicenseRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _ILicenseRepo.SaveLicense(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteLicense")]
        public ApiResponse<bool> DeleteLicense(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _ILicenseRepo.DeleteLicense(Id);
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
