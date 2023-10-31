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
        [Route("GetAllInsurances")]
        public ApiResponse<List<GetAllInsuranceResponseDTO>> GetAllInsurance()
        {
            ApiResponse<List<GetAllInsuranceResponseDTO>> response = new ApiResponse<List<GetAllInsuranceResponseDTO>>();
            try
            {
                List<GetAllInsuranceResponseDTO> result = new List<GetAllInsuranceResponseDTO>();
                result = _IInsuranceRepo.GetAllInsurance();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveInsurance")]
        public ApiResponse<bool> SaveInsurance([FromBody] GetAllInsuranceRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IInsuranceRepo.SaveInsurance(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
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

        [HttpPost("UploadInsuranceCardPhoto")]
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
