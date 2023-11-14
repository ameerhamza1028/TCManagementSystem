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
        public ApiResponse<SaveUserResponseDTO> SaveUser([FromBody] GetAllUserRequestDTO request)
        {
            ApiResponse<SaveUserResponseDTO> response = new ApiResponse<SaveUserResponseDTO>();
            try
            {
                SaveUserResponseDTO result = new SaveUserResponseDTO();
                result = _IUserRepo.SaveUser(request);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("UploadFiles")]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            try
            {
                if (files == null || files.Count == 0)
                {
                    return BadRequest("No files were selected for upload.");
                }

                string rootPath = "https://host1.farmacyapp.com/smb/file-manager/list/domainId/68";

                // Create a list to store the file paths of the uploaded files.
                List<string> uploadedFilePaths = new List<string>();

                using (var httpClient = new HttpClient())
                {
                    foreach (var file in files)
                    {
                        if (file.Length == 0)
                        {
                            continue;
                        }
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string targetUrl = Path.Combine(rootPath, uniqueFileName);

                        using (var stream = file.OpenReadStream())
                        {
                            using (var content = new StreamContent(stream))
                            {
                                using (var formData = new MultipartFormDataContent())
                                {
                                    formData.Add(content, "file", file.FileName);

                                    var response = await httpClient.PostAsync(targetUrl, formData);

                                    if (response.IsSuccessStatusCode)
                                    {
                                        uploadedFilePaths.Add(targetUrl);
                                    }
                                }
                            }
                        }
                    }
                }

                // Return the list of uploaded file URLs.
                return Ok(new { Message = "Files uploaded successfully.", FilePathList = uploadedFilePaths });
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
