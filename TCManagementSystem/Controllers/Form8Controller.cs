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
    public class Form8Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm8Repo _IForm8Repo;

        public Form8Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm8Repo IForm8Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm8Repo = IForm8Repo;
        }

        [HttpPost]
        [Route("SaveForm8")]
        public ApiResponse<bool> SaveForm8([FromBody] GetAllForm8RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm8Repo.SaveForm8(request);
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
