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
    public class Form1Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm1Repo _IForm1Repo;

        public Form1Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm1Repo IForm1Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm1Repo = IForm1Repo;
        }

        [HttpPost]
        [Route("SaveForm1")]
        public ApiResponse<bool> SaveForm1([FromBody] GetAllForm1RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm1Repo.SaveForm1(request);
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
