using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.AvailableSlot;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableSlotController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IAvailableSlotRepo _IAvailableSlotRepo;

        public AvailableSlotController(
            IConfiguration config,
            IMapper IMapper,
            IAvailableSlotRepo IAvailableSlotRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IAvailableSlotRepo = IAvailableSlotRepo;
        }

        [HttpGet]
        [Route("GetAllAvailableSlot")]
        public ApiResponse<List<GetAllSlotAvailableResponseDTO>> GetAllAvailableSlot()
        {
            ApiResponse<List<GetAllSlotAvailableResponseDTO>> response = new ApiResponse<List<GetAllSlotAvailableResponseDTO>>();
            try
            {
                List<GetAllSlotAvailableResponseDTO> result = new List<GetAllSlotAvailableResponseDTO>();
                result = _IAvailableSlotRepo.GetAllAllAvailableSlot();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetAvailableSlotById")]
        public ApiResponse<GetAllSlotAvailableResponseDTO> GetAvailableSlotById(long Id)
        {
            ApiResponse<GetAllSlotAvailableResponseDTO> response = new ApiResponse<GetAllSlotAvailableResponseDTO>();
            try
            {
                GetAllSlotAvailableResponseDTO result = new GetAllSlotAvailableResponseDTO();
                result = _IAvailableSlotRepo.GetAvailableSlotById(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveAvailableSlot")]
        public ApiResponse<bool> SaveAvailableSlot([FromBody] GetAllAvailableSlotRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IAvailableSlotRepo.SaveAvailableSlot(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteAvailableSlot")]
        public ApiResponse<bool> DeleteAvailableSlot(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IAvailableSlotRepo.DeleteAvailableSlot(Id);
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
