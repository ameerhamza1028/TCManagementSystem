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
    public class Form18Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm18Repo _IForm18Repo;

        public Form18Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm18Repo IForm18Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm18Repo = IForm18Repo;
        }

        [HttpPost]
        [Route("SaveForm18")]
        public ApiResponse<bool> SaveForm18([FromBody] GetAllForm18RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm18Repo.SaveForm18(request);
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
