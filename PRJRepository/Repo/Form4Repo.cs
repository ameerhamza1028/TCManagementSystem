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
    public class Form4Repo : IForm4Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form4Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm4(GetAllForm4RequestDTO request)
        {
            try
            {
                Form4 tcForm4 = new Form4();
                if (request.FormId == 0)
                {
                    tcForm4 = _mapper.Map<Form4>(request);
                    _context.Form4s.Add(tcForm4);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm4 = _context.Form4s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm4 = _mapper.Map(request, tcForm4);
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
