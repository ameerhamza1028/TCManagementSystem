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
    public class Form20Repo : IForm20Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form20Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm20(GetAllForm20RequestDTO request)
        {
            try
            {
                Form20 tcForm20 = new Form20();
                if (request.FormId == 0)
                {
                    tcForm20 = _mapper.Map<Form20>(request);
                    _context.Form20s.Add(tcForm20);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm20 = _context.Form20s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm20 = _mapper.Map(request, tcForm20);
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
