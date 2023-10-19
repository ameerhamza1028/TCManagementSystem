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
            [Route("GetAllBillingSetting")]
<<<<<<< HEAD
            public ApiResponse<List<GetAllBillingSettingResponseDTO>> GetAllBillingSetting()
=======
            public ApiResponse<List<GetAllBillingSettingResponseDTO>> GetAllUser()
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
            {
                ApiResponse<List<GetAllBillingSettingResponseDTO>> response = new ApiResponse<List<GetAllBillingSettingResponseDTO>>();
                try
                {
                    List<GetAllBillingSettingResponseDTO> result = new List<GetAllBillingSettingResponseDTO>();
                    result = _IBillingSettingRepo.GetAllBillingSetting();
                    response.Data = result;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpGet]
            [Route("GetBillingSettingById")]
<<<<<<< HEAD
            public ApiResponse<GetAllBillingSettingResponseDTO> GetBillingSettingById(long Id)
=======
            public ApiResponse<GetAllBillingSettingResponseDTO> GetBillingSettingById(int id)
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
            {
                ApiResponse<GetAllBillingSettingResponseDTO> response = new ApiResponse<GetAllBillingSettingResponseDTO>();
                try
                {
                    GetAllBillingSettingResponseDTO result = new GetAllBillingSettingResponseDTO();
<<<<<<< HEAD
                    result = _IBillingSettingRepo.GetBillingSettingById(Id);
=======
                    result = _IBillingSettingRepo.GetBillingSettingById(id);
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
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

            [HttpDelete]
            [Route("DeleteBillingSetting")]
<<<<<<< HEAD
            public ApiResponse<bool> DeleteBillingSetting(long Id)
=======
            public ApiResponse<bool> DeleteBillingSetting(int id)
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
            {
                ApiResponse<bool> response = new ApiResponse<bool>();
                try
                {
<<<<<<< HEAD
                    _IBillingSettingRepo.DeleteBillingSetting(Id);
=======
                    _IBillingSettingRepo.DeleteBillingSetting(id);
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
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
