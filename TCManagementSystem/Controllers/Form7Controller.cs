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
    public class Form7Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm7Repo _IForm7Repo;

        public Form7Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm7Repo IForm7Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm7Repo = IForm7Repo;
        }

        [HttpPost]
        [Route("SaveForm7")]
        public ApiResponse<bool> SaveForm7([FromBody] GetAllForm7RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm7Repo.SaveForm7(request);
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
