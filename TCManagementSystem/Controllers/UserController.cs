using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.Repo;
using PRJRepository.DTO;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IUserRepo _IUserRepo;

        public UserController(
            IConfiguration config,
            IMapper IMapper,
            IUserRepo IUserRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IUserRepo = IUserRepo;
        }

        [HttpGet]
        [Route("GetAllUser")]
        public ApiResponse<List<GetAllResponseDTO>> GetAllUser()
        {
            ApiResponse<List<GetAllResponseDTO>> response = new ApiResponse<List<GetAllResponseDTO>>();
            try
            {
                List<GetAllResponseDTO> result = new List<GetAllResponseDTO>();
                result = _IUserRepo.GetAllUser();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpGet]
        [Route("GetUserById")]
        public ApiResponse<GetAllResponseDTO> GetUserById(int id)
        {
            ApiResponse<GetAllResponseDTO> response = new ApiResponse<GetAllResponseDTO>();
            try
            {
                GetAllResponseDTO result = new GetAllResponseDTO();
                result = _IUserRepo.GetUserById(id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveUser")]
        public ApiResponse<bool> SaveUser([FromBody] GetAllRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IUserRepo.SaveUser(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public ApiResponse<bool> DeleteUser(int id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IUserRepo.DeleteUser(id);
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
