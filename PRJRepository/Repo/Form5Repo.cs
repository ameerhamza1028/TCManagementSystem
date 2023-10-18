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
    public class Form5Repo : IForm5Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form5Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm5(GetAllForm5RequestDTO request)
        {
            try
            {
                Form5 tcForm5 = new Form5();
                if (request.FormId == 0)
                {
                    tcForm5 = _mapper.Map<Form5>(request);
                    _context.Form5s.Add(tcForm5);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm5 = _context.Form5s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm5 = _mapper.Map(request, tcForm5);
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
