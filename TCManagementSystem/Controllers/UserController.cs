using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO;
using PRJRepository.DTO.User;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IUserRepo _IUserRepo;

        public UserController(
            IConfiguration config,
            IMapper IMapper,
            IUserRepo IUserRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IUserRepo = IUserRepo;
        }

        [HttpGet]
        [Route("GetAllUser")]
        public ApiResponse<List<GetAllUserResponseDTO>> GetAllUser()
        {
            ApiResponse<List<GetAllUserResponseDTO>> response = new ApiResponse<List<GetAllUserResponseDTO>>();
            try
            {
                List<GetAllUserResponseDTO> result = new List<GetAllUserResponseDTO>();
                result = _IUserRepo.GetAllUser();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveUser")]
        public ApiResponse<bool> SaveUser([FromBody] GetAllUserRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IUserRepo.SaveUser(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

            [HttpPost("UploadFiles")]
            public async Task<IActionResult> UploadFile(IFormFile file)
            {
                try
                {
                


                if (file == null || file.Length == 0)
                    {
                        return BadRequest("No file was selected for upload.");
                    }

                // Specify the path where you want to save the uploaded file.
                string patientFilesDirectory = "UserUploadFiles"; 
                string rootPath = "D:\\Web API Using Visual Sudio\\TCManagementSystem";
                string filePath = Path.Combine(rootPath, patientFilesDirectory, file.FileName);

                // Use a stream to copy the file to the specified path.
                using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    return Ok("File uploaded successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
    }
}
