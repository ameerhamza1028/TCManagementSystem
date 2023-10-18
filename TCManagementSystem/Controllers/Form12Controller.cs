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
    public class Form12Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm12Repo _IForm12Repo;

        public Form12Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm12Repo IForm12Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm12Repo = IForm12Repo;
        }

        [HttpPost]
        [Route("SaveForm12")]
        public ApiResponse<bool> SaveForm12([FromBody] GetAllForm12RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm12Repo.SaveForm12(request);
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
