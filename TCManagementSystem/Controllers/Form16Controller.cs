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
    public class Form16Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm16Repo _IForm16Repo;

        public Form16Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm16Repo IForm16Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm16Repo = IForm16Repo;
        }

        [HttpPost]
        [Route("SaveForm16")]
        public ApiResponse<bool> SaveForm16([FromBody] GetAllForm16RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm16Repo.SaveForm16(request);
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
