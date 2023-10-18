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
    public class Form13Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm13Repo _IForm13Repo;

        public Form13Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm13Repo IForm13Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm13Repo = IForm13Repo;
        }

        [HttpPost]
        [Route("SaveForm13")]
        public ApiResponse<bool> SaveForm13([FromBody] GetAllForm13RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm13Repo.SaveForm13(request);
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
