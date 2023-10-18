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
    public class Form16Repo : IForm16Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form16Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm16(GetAllForm16RequestDTO request)
        {
            try
            {
                Form16 tcForm16 = new Form16();
                if (request.FormId == 0)
                {
                    tcForm16 = _mapper.Map<Form16>(request);
                    _context.Form16s.Add(tcForm16);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm16 = _context.Form16s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm16 = _mapper.Map(request, tcForm16);
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
