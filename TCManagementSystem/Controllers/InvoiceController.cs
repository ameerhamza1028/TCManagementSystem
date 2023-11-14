using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Invoice;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
            public IConfiguration _configuration;
            private readonly IMapper _mapper;

            private readonly IInvoiceRepo _IInvoiceRepo;

            public InvoiceController(
                IConfiguration config,
                IMapper IMapper,
                IInvoiceRepo IInvoiceRepo)
            {
                _configuration = config;
                _mapper = IMapper;
                _IInvoiceRepo = IInvoiceRepo;
            }

            [HttpGet]
            [Route("GetAllInvoice")]
            public ApiResponse<List<GetAllInvoiceResponseDTO>> GetAllInvoice()
            {
                ApiResponse<List<GetAllInvoiceResponseDTO>> response = new ApiResponse<List<GetAllInvoiceResponseDTO>>();
                try
                {
                    List<GetAllInvoiceResponseDTO> result = new List<GetAllInvoiceResponseDTO>();
                    result = _IInvoiceRepo.GetAllInvoice();
                    response.Data = result;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpGet]
            [Route("GetInvoiceById")]
            public ApiResponse<GetAllInvoiceResponseDTO> GetInvoiceById(long Id)
            {
                ApiResponse<GetAllInvoiceResponseDTO> response = new ApiResponse<GetAllInvoiceResponseDTO>();
                try
                {
                    GetAllInvoiceResponseDTO result = new GetAllInvoiceResponseDTO();
                    result = _IInvoiceRepo.GetInvoiceById(Id);
                    response.Data = result;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpPost]
            [Route("SaveInvoice")]
            public ApiResponse<bool> SaveInvoice([FromBody] GetAllInvoiceRequestDTO request)
            {
                ApiResponse<bool> response = new ApiResponse<bool>();
                try
                {
                    _IInvoiceRepo.SaveInvoice(request);
                    response.Data = true;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

        [HttpPost]
        [Route("DeleteInvoice")]
            public ApiResponse<bool> DeleteInvoice(long Id)
            {
                ApiResponse<bool> response = new ApiResponse<bool>();
                try
                {
                    _IInvoiceRepo.DeleteInvoice(Id);
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
