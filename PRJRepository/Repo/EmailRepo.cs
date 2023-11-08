using AutoMapper;
using PRJRepository.DTO.Email;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class EmailRepo : IEmailRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public EmailRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllEmailResponseDTO> GetAllEmail(long Id)
        {
            List<GetAllEmailResponseDTO> response = new List<GetAllEmailResponseDTO>();
            List<Email> list = _context.Emails.Where(x => x.EmailId == Id).ToList();
            response = _mapper.Map<List<GetAllEmailResponseDTO>>(list);
            return response;
        }
        public bool DeleteEmail(long Id)
        {
            try
            {
                Email Email = _context.Emails.FirstOrDefault(x => x.EmailId == Id);
                Email.IsActive = false;
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
