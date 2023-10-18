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
    public class Form2Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm2Repo _IForm2Repo;

        public Form2Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm2Repo IForm2Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm2Repo = IForm2Repo;
        }

        [HttpPost]
        [Route("SaveForm2")]
        public ApiResponse<bool> SaveForm2([FromBody] GetAllForm2RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm2Repo.SaveForm2(request);
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
