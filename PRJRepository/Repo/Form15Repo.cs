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
    public class Form15Repo : IForm15Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form15Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm15(GetAllForm15RequestDTO request)
        {
            try
            {
                Form15 tcForm15 = new Form15();
                if (request.FormId == 0)
                {
                    tcForm15 = _mapper.Map<Form15>(request);
                    _context.Form15s.Add(tcForm15);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm15 = _context.Form15s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm15 = _mapper.Map(request, tcForm15);
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
