using AutoMapper;
using PRJRepository.DTO.Phone;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class PhoneRepo : IPhoneRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public PhoneRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllPhoneResponseDTO> GetAllPhone()
        {
            List<GetAllPhoneResponseDTO> response = new List<GetAllPhoneResponseDTO>();
            List<Models.Phone> list = _context.Phones.ToList();
            response = _mapper.Map<List<GetAllPhoneResponseDTO>>(list);
            return response;
        }

        public bool SavePhone(GetAllPhoneRequestDTO request)
        {
            try
            {
                Models.Phone Phone = new Models.Phone();
                if (request.PhoneId == 0)
                {
                    Phone = _mapper.Map<Models.Phone>(request);
                    Phone.IsActive = true;
                    Phone.CreactionDate = DateTime.UtcNow;
                    _context.Phones.Add(Phone);
                    _context.SaveChanges();
                }
                else
                {
                    Phone = _context.Phones.Where(x => x.PhoneId == request.PhoneId).FirstOrDefault();
                    Phone = _mapper.Map(request, Phone);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePhone(long Id)
        {
            try
            {
                Phone Phone = _context.Phones.FirstOrDefault(x => x.PhoneId == Id);
                Phone.IsActive = false;
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
