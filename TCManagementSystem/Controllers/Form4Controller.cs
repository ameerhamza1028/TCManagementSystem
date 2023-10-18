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
    public class Form4Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm4Repo _IForm4Repo;

        public Form4Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm4Repo IForm4Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm4Repo = IForm4Repo;
        }

        [HttpPost]
        [Route("SaveForm4")]
        public ApiResponse<bool> SaveForm4([FromBody] GetAllForm4RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm4Repo.SaveForm4(request);
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
