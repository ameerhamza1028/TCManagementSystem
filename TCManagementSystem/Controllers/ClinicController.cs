﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO;
using PRJRepository.Repo;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IClinicRepo _IClinicRepo;

        public ClinicController(
            IConfiguration config,
            IMapper IMapper,
            IClinicRepo IClinicRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IClinicRepo = IClinicRepo;
        }

        [HttpGet]
        [Route("GetAllClinic")]
        public ApiResponse<List<GetAllClinicResponseDTO>> GetAllUser()
        {
            ApiResponse<List<GetAllClinicResponseDTO>> response = new ApiResponse<List<GetAllClinicResponseDTO>>();
            try
            {
                List<GetAllClinicResponseDTO> result = new List<GetAllClinicResponseDTO>();
                result = _IClinicRepo.GetAllClinic();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetClinicById")]
        public ApiResponse<GetAllClinicResponseDTO> GetClinicById(int id)
        {
            ApiResponse<GetAllClinicResponseDTO> response = new ApiResponse<GetAllClinicResponseDTO>();
            try
            {
                GetAllClinicResponseDTO result = new GetAllClinicResponseDTO();
                result = _IClinicRepo.GetClinicById(id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveClinic")]
        public ApiResponse<bool> SaveClinic([FromBody] GetAllClinicRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IClinicRepo.SaveClinic(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteClinic")]
        public ApiResponse<bool> DeleteClinic(int id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IClinicRepo.DeleteClinic(id);
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