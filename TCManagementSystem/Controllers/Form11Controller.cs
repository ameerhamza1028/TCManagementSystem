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
    public class Form11Controller : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IForm11Repo _IForm11Repo;

        public Form11Controller(
            IConfiguration config,
            IMapper IMapper,
            IForm11Repo IForm11Repo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IForm11Repo = IForm11Repo;
        }

        [HttpPost]
        [Route("SaveForm11")]
        public ApiResponse<bool> SaveForm11([FromBody] GetAllForm11RequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IForm11Repo.SaveForm11(request);
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
