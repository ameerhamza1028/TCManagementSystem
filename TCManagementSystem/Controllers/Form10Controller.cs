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
    public class Form10Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm10Repo _IForm10Repo;

        public Form10Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm10Repo IForm10Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm10Repo = IForm10Repo;
        }

        [HttpPost]
        [Route("SaveForm10")]
        public ApiResponse<bool> SaveForm10([FromBody] GetAllForm10RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm10Repo.SaveForm10(request);
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
