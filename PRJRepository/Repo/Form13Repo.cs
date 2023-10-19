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
    public class Form13Repo : IForm13Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form13Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm13(GetAllForm13RequestDTO request)
        {
            try
            {
                Form13 tcForm13 = new Form13();
                if (request.FormId == 0)
                {
                    tcForm13 = _mapper.Map<Form13>(request);
                    _context.Form13s.Add(tcForm13);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm13 = _context.Form13s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm13 = _mapper.Map(request, tcForm13);
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
