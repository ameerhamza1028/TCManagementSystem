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
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public PhoneRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllPhoneResponseDTO> GetAllPhone(long Id)
        {
            List<GetAllPhoneResponseDTO> response = new List<GetAllPhoneResponseDTO>();
            List<Phone> list = _context.Phones.Where(x => x.ClientId == Id).ToList();
            response = _mapper.Map<List<GetAllPhoneResponseDTO>>(list);
            return response;
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
