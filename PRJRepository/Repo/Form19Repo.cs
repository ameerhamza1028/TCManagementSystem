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
    public class Form19Repo : IForm19Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form19Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm19(GetAllForm19RequestDTO request)
        {
            try
            {
                Form19 tcForm19 = new Form19();
                if (request.FormId == 0)
                {
                    tcForm19 = _mapper.Map<Form19>(request);
                    _context.Form19s.Add(tcForm19);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm19 = _context.Form19s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm19 = _mapper.Map(request, tcForm19);
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
