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
    public class Form14Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm14Repo _IForm14Repo;

        public Form14Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm14Repo IForm14Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm14Repo = IForm14Repo;
        }

        [HttpPost]
        [Route("SaveForm14")]
        public ApiResponse<bool> SaveForm14([FromBody] GetAllForm14RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm14Repo.SaveForm14(request);
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
