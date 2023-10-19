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
    public class Form6Repo : IForm6Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form6Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm6(GetAllForm6RequestDTO request)
        {
            try
            {
                Form6 tcForm6 = new Form6();
                if (request.FormId == 0)
                {
                    tcForm6 = _mapper.Map<Form6>(request);
                    _context.Form6s.Add(tcForm6);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm6 = _context.Form6s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm6 = _mapper.Map(request, tcForm6);
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
