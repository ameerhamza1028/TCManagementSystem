using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRJRepository.DTO.CheckAvailability;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class CheckAvailabilityRepo : ICheckAvailabilityRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public CheckAvailabilityRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetAllCheckAvailabilityResponseDTO GetCheckAvailability(GetAllCheckAvailabilityRequestDTO request)
        {
            GetAllCheckAvailabilityResponseDTO response = new GetAllCheckAvailabilityResponseDTO();
            AvailableSlot slot = _context.AvailableSlots.Where(x => x.ClicianId == request.ClinicianId && x.SlotDate == request.SelectDate && x.LocationId == request.LocationId).FirstOrDefault();
            response.SelectDate = slot.SlotDate;
            // response = _mapper.Map<GetAllCheckAvailabilityResponseDTO>(item);
            return response;
        }
    }
}
