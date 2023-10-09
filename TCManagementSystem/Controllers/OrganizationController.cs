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
        public class OrganizationController : ControllerBase
        {
            public IConfiguration _configuration;
            private readonly IMapper _mapper;

            private readonly IOrganizationRepo _IOrganizationRepo;

            public OrganizationController(
                IConfiguration config,
                IMapper IMapper,
                IOrganizationRepo IOrganizationRepo)
            {
                _configuration = config;
                _mapper = IMapper;
                _IOrganizationRepo = IOrganizationRepo;
            }

            [HttpGet]
            [Route("GetAllOrganization")]
            public ApiResponse<List<GetAllOrganizationResponseDTO>> GetAllOrganization()
            {
                ApiResponse<List<GetAllOrganizationResponseDTO>> response = new ApiResponse<List<GetAllOrganizationResponseDTO>>();
                try
                {
                    List<GetAllOrganizationResponseDTO> result = new List<GetAllOrganizationResponseDTO>();
                    result = _IOrganizationRepo.GetAllOrganization();
                    response.Data = result;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpGet]
            [Route("GetOrganizationById")]
            public ApiResponse<GetAllOrganizationResponseDTO> GetSubscriptionById(int Orgid)
            {
                ApiResponse<GetAllOrganizationResponseDTO> response = new ApiResponse<GetAllOrganizationResponseDTO>();
                try
                {
                    GetAllOrganizationResponseDTO result = new GetAllOrganizationResponseDTO();
                    result = _IOrganizationRepo.GetOrganizationById(Orgid);
                    response.Data = result;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpPost]
            [Route("SaveOrganization")]
            public ApiResponse<bool> SaveOrganization([FromBody] GetAllOrganizationRequestDTO request)
            {
                ApiResponse<bool> response = new ApiResponse<bool>();
                try
                {
                    _IOrganizationRepo.SaveOrganization(request);
                    response.Data = true;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpDelete]
            [Route("DeleteOrganization")]
            public ApiResponse<bool> DeleteOrganization(int Orgid)
            {
                ApiResponse<bool> response = new ApiResponse<bool>();
                try
                {
                    _IOrganizationRepo.DeleteOrganization(Orgid);
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

