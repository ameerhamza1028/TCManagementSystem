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
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public EmailRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllEmailResponseDTO> GetAllEmail()
        {
            List<GetAllEmailResponseDTO> response = new List<GetAllEmailResponseDTO>();
            List<Models.Email> list = _context.Emails.ToList();
            response = _mapper.Map<List<GetAllEmailResponseDTO>>(list);
            return response;
        }

        public bool SaveEmail(GetAllEmailRequestDTO request)
        {
            try
            {
                Models.Email Email = new Models.Email();
                if (request.EmailId == 0)
                {
                    Email = _mapper.Map<Models.Email>(request);
                    Email.IsActive = true;
                    Email.CreationDate = DateTime.UtcNow;
                    _context.Emails.Add(Email);
                    _context.SaveChanges();
                }
                else
                {
                    Email = _context.Emails.Where(x => x.EmailId == request.EmailId).FirstOrDefault();
                    Email = _mapper.Map(request, Email);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
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
