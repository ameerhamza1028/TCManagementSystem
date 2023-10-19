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
    public class Form7Repo : IForm7Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form7Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm7(GetAllForm7RequestDTO request)
        {
            try
            {
                Form7 tcForm7 = new Form7();
                if (request.FormId == 0)
                {
                    tcForm7 = _mapper.Map<Form7>(request);
                    _context.Form7s.Add(tcForm7);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm7 = _context.Form7s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm7 = _mapper.Map(request, tcForm7);
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
