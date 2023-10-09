﻿using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class ClinicLocationRepo : IClinicLocationRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public ClinicLocationRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllClinicLocationResponseDTO> GetAllClinicLocation()
        {
            List<GetAllClinicLocationResponseDTO> response = new List<GetAllClinicLocationResponseDTO>();
            List<ClinicLocation> list = _context.ClinicLocations.ToList();
            response = _mapper.Map<List<GetAllClinicLocationResponseDTO>>(list);
            return response;
        }

        public GetAllClinicLocationResponseDTO GetClinicLocationById(int id)
        {
            GetAllClinicLocationResponseDTO response = new GetAllClinicLocationResponseDTO();
            ClinicLocation item = _context.ClinicLocations.Where(x => x.LocationId == id).FirstOrDefault();
            response = _mapper.Map<GetAllClinicLocationResponseDTO>(item);
            return response;
        }

        public bool SaveClinicLocation(GetAllClinicLocationRequestDTO request)
        {
            try
            {
                ClinicLocation ClinicLocation = new ClinicLocation();
                if (request.LocationId == 0)
                {
                    ClinicLocation = _mapper.Map<ClinicLocation>(request);
                    _context.ClinicLocations.Add(ClinicLocation);
                    _context.SaveChanges();
                }
                else
                {
                    ClinicLocation = _context.ClinicLocations.Where(x => x.LocationId == request.LocationId).FirstOrDefault();
                    ClinicLocation = _mapper.Map(request, ClinicLocation);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteClinicLocation(int id)
        {
            try
            {
                var ClinicLocation = _context.ClinicLocations.FirstOrDefault(x => x.LocationId == id);
                _context.ClinicLocations.Remove(ClinicLocation);
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