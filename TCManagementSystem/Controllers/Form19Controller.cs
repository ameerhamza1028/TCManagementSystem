using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO;
using PRJRepository.Repo;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Form19Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm19Repo _IForm19Repo;

        public Form19Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm19Repo IForm19Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm19Repo = IForm19Repo;
        }

        [HttpPost]
        [Route("SaveForm19")]
        public ApiResponse<bool> SaveForm19([FromBody] GetAllForm19RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm19Repo.SaveForm19(request);
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
