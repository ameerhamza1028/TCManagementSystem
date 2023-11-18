using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.ClientNote;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminNoteController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IAdminNoteRepo _IAdminNoteRepo;

        public AdminNoteController(
            IConfiguration config,
            IMapper IMapper,
            IAdminNoteRepo IAdminNoteRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IAdminNoteRepo = IAdminNoteRepo;
        }

        [HttpGet]
        [Route("GetAllAdminNoteByAdminId")]

        public ApiResponse<List<GetAllAdminNoteResponseDTO>> GetAllNote(long Id)
        {
            ApiResponse<List<GetAllAdminNoteResponseDTO>> response = new ApiResponse<List<GetAllAdminNoteResponseDTO>>();
            try
            {
                List<GetAllAdminNoteResponseDTO> result = new List<GetAllAdminNoteResponseDTO>();
                result = _IAdminNoteRepo.GetAllAdminNote(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetAdminNoteById")]

        public ApiResponse<GetAllAdminNoteRequestDTO> GetAdminNoteById(long Id)
        {
            ApiResponse<GetAllAdminNoteRequestDTO> response = new ApiResponse<GetAllAdminNoteRequestDTO>();
            try
            {
                GetAllAdminNoteRequestDTO result = new GetAllAdminNoteRequestDTO();

                result = _IAdminNoteRepo.GetAdminNoteById(Id);

                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveAdminNote")]
        public ApiResponse<bool> SaveAdminNote([FromBody] GetAllAdminNoteRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IAdminNoteRepo.SaveAdminNote(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteAdminNote")]

        public ApiResponse<bool> DeleteAdminNote(long Id)

        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {

                _IAdminNoteRepo.DeleteAdminNote(Id);

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
