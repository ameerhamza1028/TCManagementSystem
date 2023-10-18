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
    public class Form12Repo : IForm12Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form12Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm12(GetAllForm12RequestDTO request)
        {
            try
            {
                Form12 tcForm12 = new Form12();
                if (request.FormId == 0)
                {
                    tcForm12 = _mapper.Map<Form12>(request);
                    _context.Form12s.Add(tcForm12);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm12 = _context.Form12s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm12 = _mapper.Map(request, tcForm12);
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
