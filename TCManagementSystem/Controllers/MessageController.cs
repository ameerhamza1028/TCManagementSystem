using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Message;
using PRJRepository.DTO.Message;
using PRJRepository.DTO.Message;
using PRJRepository.Interface;
using PRJRepository.Repo;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IMessageRepo _IMessageRepo;

        public MessageController(
            IConfiguration config,
            IMapper IMapper,
            IMessageRepo IMessageRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IMessageRepo = IMessageRepo;
        }

        [HttpGet]
        [Route("GetAllPeopleList")]
        public ApiResponse<List<GetMessageResponseDTO>> GetAllPeople()
        {
            ApiResponse<List<GetMessageResponseDTO>> response = new ApiResponse<List<GetMessageResponseDTO>>();
            try
            {
                List<GetMessageResponseDTO> result = new List<GetMessageResponseDTO>();
                result = _IMessageRepo.GetAllMessage();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetAllMessages")]
        public ApiResponse<List<GetMessageResponseDTO>> GetAllMessage()
        {
            ApiResponse<List<GetMessageResponseDTO>> response = new ApiResponse<List<GetMessageResponseDTO>>();
            try
            {
                List<GetMessageResponseDTO> result = new List<GetMessageResponseDTO>();
                result = _IMessageRepo.GetAllMessage();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetMessageById")]
        public ApiResponse<List<GetMessageResponseDTO>> GetMessageById(long Id)
        {
            ApiResponse<List<GetMessageResponseDTO>> response = new ApiResponse<List<GetMessageResponseDTO>>();
            try
            {
                List<GetMessageResponseDTO> result = new List<GetMessageResponseDTO>();
                result = _IMessageRepo.GetMessageById(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveMessage")]
        public ApiResponse<bool> SaveMessage([FromBody] GetMessageRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IMessageRepo.SaveMessage(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteMessage")]
        public ApiResponse<bool> DeleteMessage(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IMessageRepo.DeleteMessage(Id);
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
