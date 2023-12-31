﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJRepository.DTO.Appointment;
using PRJRepository.Interface;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IAppointmentRepo _IAppointmentRepo;

        public AppointmentController(
            IConfiguration config,
            IMapper IMapper,
            IAppointmentRepo IAppointmentRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _IAppointmentRepo = IAppointmentRepo;
        }

        [HttpGet]
        [Route("GetAllAppointment")]
        public ApiResponse<List<GetAllAppointmentResponseDTO>> GetAllAppointment()
        {
            ApiResponse<List<GetAllAppointmentResponseDTO>> response = new ApiResponse<List<GetAllAppointmentResponseDTO>>();
            try
            {
                List<GetAllAppointmentResponseDTO> result = new List<GetAllAppointmentResponseDTO>();
                result = _IAppointmentRepo.GetAllAppointment();
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetAppointmentById")]
        public ApiResponse<GetAllAppointmentRequestDTO> GetAppointmentById(long Id)
        {
            ApiResponse<GetAllAppointmentRequestDTO> response = new ApiResponse<GetAllAppointmentRequestDTO>();
            try
            {
                GetAllAppointmentRequestDTO result = new GetAllAppointmentRequestDTO();
                result = _IAppointmentRepo.GetAppointmentById(Id);
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("SaveAppointment")]
        public ApiResponse<bool> SaveAppointment([FromBody] GetAllAppointmentRequestDTO request)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IAppointmentRepo.SaveAppointment(request);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteAppointment")]
        public ApiResponse<bool> DeleteAppointment(long Id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                _IAppointmentRepo.DeleteAppointment(Id);
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
