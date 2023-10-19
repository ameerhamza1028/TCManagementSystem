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
    public class Form9Repo : IForm9Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form9Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm9(GetAllForm9RequestDTO request)
        {
            try
            {
                Form9 tcForm9 = new Form9();
                if (request.FormId == 0)
                {
                    tcForm9 = _mapper.Map<Form9>(request);
                    _context.Form9s.Add(tcForm9);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm9 = _context.Form9s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm9 = _mapper.Map(request, tcForm9);
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
