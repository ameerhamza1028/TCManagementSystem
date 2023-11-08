using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Email;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IEmailRepo _IEmailRepo;

        public EmailController(
            IConfiguration config,
            IMapper IMapper,
            IEmailRepo IEmailRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IEmailRepo = IEmailRepo;
        }

        [HttpGet]
        [Route("GetAllEmails")]
        public ApiResponse<List<GetAllEmailResponseDTO>> GetAllEmail(long Id)
        {
            ApiResponse<List<GetAllEmailResponseDTO>> response = new ApiResponse<List<GetAllEmailResponseDTO>>();
            try
            {
                List<GetAllEmailResponseDTO> result = new List<GetAllEmailResponseDTO>();
                result = _IEmailRepo.GetAllEmail(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteEmail")]
        public ApiResponse<bool> DeleteEmail(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IEmailRepo.DeleteEmail(Id);
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
