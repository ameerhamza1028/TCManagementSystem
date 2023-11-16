using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO;
using PRJRepository.DTO.Message;
using PRJRepository.DTO.User;
using PRJRepository.Interface;
using PRJRepository.Repo;
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
        [Route("GetAllUserByClinicId")]
        public ApiResponse<List<GetAllUserResponseDTO>> GetAllUserByClinicId(long Id)
        {
            ApiResponse<List<GetAllUserResponseDTO>> response = new ApiResponse<List<GetAllUserResponseDTO>>();
            try
            {
                List<GetAllUserResponseDTO> result = new List<GetAllUserResponseDTO>();
                result = _IUserRepo.GetAllUserByClinicId(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetUserById")]
        public ApiResponse<EditUserResponseDTO> GetUserById(long Id)
        {
            ApiResponse<EditUserResponseDTO> response = new ApiResponse<EditUserResponseDTO>();
            try
            {
                EditUserResponseDTO result = new EditUserResponseDTO();
                result = _IUserRepo.GetUserById(Id);
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

        [HttpPost]
        [Route("UploadFiles")]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files, [FromServices] IWebHostEnvironment hostingEnvironment)
        {
            try
            {
                if (files == null || files.Count == 0)
                {
                    return BadRequest("No files were selected for upload.");
                }

                // Get the root path for wwwroot folder
                string rootPath = Path.Combine(hostingEnvironment.WebRootPath, "UserUpload");

                // Create a list to store the file information of the uploaded files.
                List<object> uploadedFileDetails = new List<object>();

                foreach (var file in files)
                {
                    if (file.Length == 0)
                    {
                        continue;
                    }

                    string uniqueFileName = file.FileName;
                    string targetPath = Path.Combine(rootPath, uniqueFileName);

                    using (var stream = new FileStream(targetPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Add file information to the list
                    var fileDetails = new
                    {
                        FileName = uniqueFileName,
                        FilePath = targetPath
                    };

                    uploadedFileDetails.Add(fileDetails);
                }

                // Return the list of uploaded file details.
                return Ok(new { Message = "Files uploaded successfully.", FileDetailsList = uploadedFileDetails });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpPost]
        [Route("DeleteUser")]
        public ApiResponse<bool> DeleteUser(long Id,string Name)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IUserRepo.DeleteUser(Id,Name);
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
