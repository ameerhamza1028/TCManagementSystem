using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.ClientNote;
using PRJRepository.DTO.EditClientDocument;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditClientDocumentController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IEditClientDocumentRepo _IEditClientDocumentRepo;

        public EditClientDocumentController(
            IConfiguration config,
            IMapper IMapper,
            IEditClientDocumentRepo IEditClientDocumentRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IEditClientDocumentRepo = IEditClientDocumentRepo;
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
                string rootPath = Path.Combine(hostingEnvironment.WebRootPath, "EditClientDocumentUpload");

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
        [Route("GetAllEditClientDocumentByClientId")]

        public ApiResponse<List<EditClientDocumentResponseDTO>> GetAllNote(long Id)
        {
            ApiResponse<List<EditClientDocumentResponseDTO>> response = new ApiResponse<List<EditClientDocumentResponseDTO>>();
            try
            {
                List<EditClientDocumentResponseDTO> result = new List<EditClientDocumentResponseDTO>();
                result = _IEditClientDocumentRepo.GetAllEditClientDocument(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetEditClientDocumentById")]

        public ApiResponse<EditClientDocumentRequestDTO> GetEditClientDocumentById(long Id)
        {
            ApiResponse<EditClientDocumentRequestDTO> response = new ApiResponse<EditClientDocumentRequestDTO>();
            try
            {
                EditClientDocumentRequestDTO result = new EditClientDocumentRequestDTO();

                result = _IEditClientDocumentRepo.GetEditClientDocumentById(Id);

                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveEditClientDocument")]
        public ApiResponse<bool> SaveEditClientDocument([FromBody] EditClientDocumentRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IEditClientDocumentRepo.SaveEditClientDocument(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteEditClientDocument")]

        public ApiResponse<bool> DeleteEditClientDocument(long Id)

        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {

                _IEditClientDocumentRepo.DeleteEditClientDocument(Id);

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
