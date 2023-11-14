using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.BillingSetting;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingSettingController : ControllerBase
    {
            public IConfiguration _configuration;
            private readonly IMapper _mapper;

            private readonly IBillingSettingRepo _IBillingSettingRepo;

            public BillingSettingController(
                IConfiguration config,
                IMapper IMapper,
                IBillingSettingRepo IBillingSettingRepo)
            {
                _configuration = config;
                _mapper = IMapper;
                _IBillingSettingRepo = IBillingSettingRepo;
            }

            [HttpGet]
            [Route("GetBillingSettingById")]

            public ApiResponse<GetAllBillingSettingResponseDTO> GetBillingSettingById(long Id)
            {
                ApiResponse<GetAllBillingSettingResponseDTO> response = new ApiResponse<GetAllBillingSettingResponseDTO>();
                try
                {
                    GetAllBillingSettingResponseDTO result = new GetAllBillingSettingResponseDTO();
                    result = _IBillingSettingRepo.GetBillingSettingById(Id);
                    response.Data = result;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpPost]
            [Route("SaveBillingSetting")]
            public ApiResponse<bool> SaveBillingSetting([FromBody] GetAllBillingSettingRequestDTO request)
            {
                ApiResponse<bool> response = new ApiResponse<bool>();
                try
                {
                    _IBillingSettingRepo.SaveBillingSetting(request);
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
