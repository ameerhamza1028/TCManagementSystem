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
    public class Form5Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm5Repo _IForm5Repo;

        public Form5Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm5Repo IForm5Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm5Repo = IForm5Repo;
        }

        [HttpPost]
        [Route("SaveForm5")]
        public ApiResponse<bool> SaveForm5([FromBody] GetAllForm5RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm5Repo.SaveForm5(request);
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
