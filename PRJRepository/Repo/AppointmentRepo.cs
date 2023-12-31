﻿using AutoMapper;
using Newtonsoft.Json;
using PRJRepository.DTO.Appointment;
using PRJRepository.Interface;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public AppointmentRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllAppointmentResponseDTO> GetAllAppointment()
        {
            List<GetAllAppointmentResponseDTO> response = new List<GetAllAppointmentResponseDTO>();
            List<Appointment> list = _context.Appointments.ToList();
            response = _mapper.Map<List<GetAllAppointmentResponseDTO>>(list);
            return response;
        }

        public GetAllAppointmentRequestDTO GetAppointmentById(long Id)
        {
            GetAllAppointmentRequestDTO response = new GetAllAppointmentRequestDTO();
            Appointment item = _context.Appointments.Where(x => x.ClientId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllAppointmentRequestDTO>(item);
            return response;
        }

        public bool SaveAppointment(GetAllAppointmentRequestDTO request)
        {
            try
            {
                if (request.AppointmentId == 0)
                {
                    Appointment appointment = _mapper.Map<Appointment>(request);

                    if (TimeSpan.TryParse(request.Time, out TimeSpan parsedTime))
                    {
                        appointment.Time = parsedTime;
                        appointment.IsActive = true;
                        appointment.CreationDate = DateTime.UtcNow;
                        _context.Appointments.Add(appointment);
                        _context.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Appointment appointment = _context.Appointments.FirstOrDefault(x => x.AppointmentId == request.AppointmentId);
                    if (appointment != null)
                    {
                        _mapper.Map(request, appointment);
                        if (TimeSpan.TryParse(request.Time, out TimeSpan parsedTime))
                        {
                            appointment.Time = parsedTime;
                            _context.SaveChanges();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAppointment(long Id)
        {
            try
            {
                Appointment appointment = _context.Appointments.FirstOrDefault(x => x.AppointmentId == Id);
                appointment.IsActive=false;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
