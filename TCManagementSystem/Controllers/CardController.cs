using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Card;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly ICardRepo _ICardRepo;

        public CardController(
            IConfiguration config,
            IMapper IMapper,
            ICardRepo ICardRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _ICardRepo = ICardRepo;
        }

        [HttpGet]
        [Route("GetCardsByClientId")]
        public ApiResponse<List<GetAllCardResponseDTO>> GetAllCard(long Id)
        {
            ApiResponse<List<GetAllCardResponseDTO>> response = new ApiResponse<List<GetAllCardResponseDTO>>();
            try
            {
                List<GetAllCardResponseDTO> result = new List<GetAllCardResponseDTO>();
                result = _ICardRepo.GetAllCard(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteCard")]
        public ApiResponse<bool> DeleteCard(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _ICardRepo.DeleteCard(Id);
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
