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
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromServices] IWebHostEnvironment hostingEnvironment)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file selected for upload.");
                }

                // Get the root path for wwwroot folder
                string rootPath = Path.Combine(hostingEnvironment.WebRootPath, "ImportClientUpload");

                // Generate a unique file name
                string uniqueFileName = file.FileName;
                string targetPath = Path.Combine(rootPath, uniqueFileName);

                using (var stream = new FileStream(targetPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Return file information
                var fileDetails = new
                {
                    FileName = uniqueFileName,
                    FilePath = targetPath
                };

                return Ok(new { Message = "File uploaded successfully.", FileDetails = fileDetails });
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
