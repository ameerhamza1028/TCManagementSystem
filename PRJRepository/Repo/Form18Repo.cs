using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class Form18Repo : IForm18Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form18Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm18(GetAllForm18RequestDTO request)
        {
            try
            {
                Form18 tcForm18 = new Form18();
                if (request.FormId == 0)
                {
                    tcForm18 = _mapper.Map<Form18>(request);
                    _context.Form18s.Add(tcForm18);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm18 = _context.Form18s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm18 = _mapper.Map(request, tcForm18);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
