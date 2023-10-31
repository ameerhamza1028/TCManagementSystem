using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Phone;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IPhoneRepo _IPhoneRepo;

        public PhoneController(
            IConfiguration config,
            IMapper IMapper,
            IPhoneRepo IPhoneRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IPhoneRepo = IPhoneRepo;
        }

        [HttpGet]
        [Route("GetAllPhones")]
        public ApiResponse<List<GetAllPhoneResponseDTO>> GetAllPhone()
        {
            ApiResponse<List<GetAllPhoneResponseDTO>> response = new ApiResponse<List<GetAllPhoneResponseDTO>>();
            try
            {
                List<GetAllPhoneResponseDTO> result = new List<GetAllPhoneResponseDTO>();
                result = _IPhoneRepo.GetAllPhone();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SavePhone")]
        public ApiResponse<bool> SavePhone([FromBody] GetAllPhoneRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IPhoneRepo.SavePhone(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeletePhone")]
        public ApiResponse<bool> DeletePhone(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IPhoneRepo.DeletePhone(Id);
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
