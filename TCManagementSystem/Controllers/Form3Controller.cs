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
    public class Form3Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm3Repo _IForm3Repo;

        public Form3Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm3Repo IForm3Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm3Repo = IForm3Repo;
        }

        [HttpPost]
        [Route("SaveForm3")]
        public ApiResponse<bool> SaveForm3([FromBody] GetAllForm3RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm3Repo.SaveForm3(request);
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
