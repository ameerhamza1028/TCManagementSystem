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
    public class Form9Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm9Repo _IForm9Repo;

        public Form9Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm9Repo IForm9Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm9Repo = IForm9Repo;
        }

        [HttpPost]
        [Route("SaveForm9")]
        public ApiResponse<bool> SaveForm9([FromBody] GetAllForm9RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm9Repo.SaveForm9(request);
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
