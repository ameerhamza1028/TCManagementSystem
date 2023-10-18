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
    public class Form17Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm17Repo _IForm17Repo;

        public Form17Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm17Repo IForm17Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm17Repo = IForm17Repo;
        }

        [HttpPost]
        [Route("SaveForm17")]
        public ApiResponse<bool> SaveForm17([FromBody] GetAllForm17RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm17Repo.SaveForm17(request);
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
