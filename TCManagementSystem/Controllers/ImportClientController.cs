using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.ImportClient;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportClientController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IImportClientRepo _IImportClientRepo;

        public ImportClientController(
            IConfiguration config,
            IMapper IMapper,
            IImportClientRepo IImportClientRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IImportClientRepo = IImportClientRepo;
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

        [HttpGet]
        [Route("GetAllImportClient")]
        public ApiResponse<List<GetAllImportClientResponseDTO>> GetAllImportClient()
        {
            ApiResponse<List<GetAllImportClientResponseDTO>> response = new ApiResponse<List<GetAllImportClientResponseDTO>>();
            try
            {
                List<GetAllImportClientResponseDTO> result = new List<GetAllImportClientResponseDTO>();
                result = _IImportClientRepo.GetAllImportClient();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetImportClientById")]
        public ApiResponse<GetAllImportClientRequestDTO> GetImportClientById(long Id)
        {
            ApiResponse<GetAllImportClientRequestDTO> response = new ApiResponse<GetAllImportClientRequestDTO>();
            try
            {
                GetAllImportClientRequestDTO result = new GetAllImportClientRequestDTO();
                result = _IImportClientRepo.GetImportClientById(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveImportClient")]
        public ApiResponse<bool> SaveImportClient([FromBody] GetAllImportClientRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IImportClientRepo.SaveImportClient(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteImportClient")]
        public ApiResponse<bool> DeleteImportClient(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IImportClientRepo.DeleteImportClient(Id);
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
