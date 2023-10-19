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
    public class Form15Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm15Repo _IForm15Repo;

        public Form15Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm15Repo IForm15Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm15Repo = IForm15Repo;
        }

        [HttpPost]
        [Route("SaveForm15")]
        public ApiResponse<bool> SaveForm15([FromBody] GetAllForm15RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm15Repo.SaveForm15(request);
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
