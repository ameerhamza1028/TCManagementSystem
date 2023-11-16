using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Insurance;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IInsuranceRepo _IInsuranceRepo;

        public InsuranceController(
            IConfiguration config,
            IMapper IMapper,
            IInsuranceRepo IInsuranceRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IInsuranceRepo = IInsuranceRepo;
        }

        [HttpGet]
        [Route("GetInsurancesByClientId")]
        public ApiResponse<List<GetAllInsuranceResponseDTO>> GetAllInsurance(long Id)
        {
            ApiResponse<List<GetAllInsuranceResponseDTO>> response = new ApiResponse<List<GetAllInsuranceResponseDTO>>();
            try
            {
                List<GetAllInsuranceResponseDTO> result = new List<GetAllInsuranceResponseDTO>();
                result = _IInsuranceRepo.GetAllInsurance(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteInsurance")]
        public ApiResponse<bool> DeleteInsurance(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IInsuranceRepo.DeleteInsurance(Id);
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
                string rootPath = Path.Combine(hostingEnvironment.WebRootPath, "InsuranceUpload");

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
    }
}
