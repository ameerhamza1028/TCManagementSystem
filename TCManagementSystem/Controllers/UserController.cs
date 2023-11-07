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

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            try
            {
                if (files == null || files.Count == 0)
                {
                    return BadRequest("No files were selected for upload.");
                }

                // Specify the directory where you want to save the uploaded files.
                string patientFilesDirectory = "UserUploadFiles";
                string rootPath = "E:\\Quamtumz Work\\TCManagementSystem";
                string directoryPath = Path.Combine(rootPath, patientFilesDirectory);

                // Create the directory if it doesn't exist.
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Create a list to store the file paths of the uploaded files.
                List<string> uploadedFilePaths = new List<string>();

                // Process each uploaded file.
                foreach (var file in files)
                {
                    if (file.Length == 0)
                    {
                        // You may want to log or handle this case differently.
                        continue;
                    }

                    // Generate a unique file name to avoid overwriting existing files.
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(directoryPath, uniqueFileName);

                    // Use a stream to copy the file to the specified path.
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Add the file path to the list of uploaded file paths.
                    uploadedFilePaths.Add(filePath);
                }

                // Return the list of uploaded file paths.
                return Ok(new { Message = "Files uploaded successfully.", FilePathList = uploadedFilePaths });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpDelete]
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
