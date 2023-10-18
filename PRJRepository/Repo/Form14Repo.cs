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
    public class Form14Repo : IForm14Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form14Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm14(GetAllForm14RequestDTO request)
        {
            try
            {
                Form14 tcForm14 = new Form14();
                if (request.FormId == 0)
                {
                    tcForm14 = _mapper.Map<Form14>(request);
                    _context.Form14s.Add(tcForm14);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm14 = _context.Form14s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm14 = _mapper.Map(request, tcForm14);
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
