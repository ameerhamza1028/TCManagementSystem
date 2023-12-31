﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Organization;
using PRJRepository.Interface;
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
            public ApiResponse<GetAllOrganizationResponseDTO> GetOrganizationById(long Id)
            {
                ApiResponse<GetAllOrganizationResponseDTO> response = new ApiResponse<GetAllOrganizationResponseDTO>();
                try
                {
                    GetAllOrganizationResponseDTO result = new GetAllOrganizationResponseDTO();
                    result = _IOrganizationRepo.GetOrganizationById(Id);
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

        [HttpPost]
        [Route("DeleteOrganization")]
            public ApiResponse<bool> DeleteOrganization(long Id)
            {
                ApiResponse<bool> response = new ApiResponse<bool>();
                try
                {
                    _IOrganizationRepo.DeleteOrganization(Id);
                    response.Data = true;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }

            [HttpPost("UploadLogo")]
            public async Task<IActionResult> UploadFile(IFormFile file)
            {
                try
                {



                    if (file == null || file.Length == 0)
                    {
                        return BadRequest("No file was selected for upload.");
                    }

                    // Specify the path where you want to save the uploaded file.
                    string patientFilesDirectory = "UserUploadFiles";
                    string rootPath = "D:\\Web API Using Visual Sudio\\TCManagementSystem";
                    string filePath = Path.Combine(rootPath, patientFilesDirectory, file.FileName);

                    // Use a stream to copy the file to the specified path.
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    return Ok("File uploaded successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

        }
}

