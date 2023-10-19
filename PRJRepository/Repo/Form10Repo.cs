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
    public class Form10Repo : IForm10Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form10Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm10(GetAllForm10RequestDTO request)
        {
            try
            {
                Form10 tcForm10 = new Form10();
                if (request.FormId == 0)
                {
                    tcForm10 = _mapper.Map<Form10>(request);
                    _context.Form10s.Add(tcForm10);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm10 = _context.Form10s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm10 = _mapper.Map(request, tcForm10);
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
