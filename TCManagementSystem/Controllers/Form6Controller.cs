using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO;
using PRJRepository.Repo;
using System.Net.Http.Headers;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Form6Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm6Repo _IForm6Repo;

        public Form6Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm6Repo IForm6Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm6Repo = IForm6Repo;
        }

        [HttpPost]
        [Route("SaveForm6")]
        public ApiResponse<bool> SaveForm6([FromBody] GetAllForm6RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm6Repo.SaveForm6(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadFiles")]
        public IActionResult UploadFiles(IFormFile file)
        {
            try
            {
                var folderName = Path.Combine("D:\\Web API Using Visual Sudio\\TCManagementSystem", "PatientFiles");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = Guid.NewGuid() + "" + DateTime.UtcNow.Ticks + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Replace("-", "").Replace("_", "").Replace(" ", "").Trim('"').ToLower();
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
