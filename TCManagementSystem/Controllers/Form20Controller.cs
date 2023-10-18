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
    public class Form20Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm20Repo _IForm20Repo;

        public Form20Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm20Repo IForm20Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm20Repo = IForm20Repo;
        }

        [HttpPost]
        [Route("SaveForm20")]
        public ApiResponse<bool> SaveForm20([FromBody] GetAllForm20RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm20Repo.SaveForm20(request);
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
