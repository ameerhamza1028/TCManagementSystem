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
    public class Form17Repo : IForm17Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form17Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm17(GetAllForm17RequestDTO request)
        {
            try
            {
                Form17 tcForm17 = new Form17();
                if (request.FormId == 0)
                {
                    tcForm17 = _mapper.Map<Form17>(request);
                    _context.Form17s.Add(tcForm17);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm17 = _context.Form17s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm17 = _mapper.Map(request, tcForm17);
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
