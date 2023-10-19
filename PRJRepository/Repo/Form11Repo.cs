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
    public class Form11Repo : IForm11Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form11Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm11(GetAllForm11RequestDTO request)
        {
            try
            {
                Form11 tcForm11 = new Form11();
                if (request.FormId == 0)
                {
                    tcForm11 = _mapper.Map<Form11>(request);
                    _context.Form11s.Add(tcForm11);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm11 = _context.Form11s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm11 = _mapper.Map(request, tcForm11);
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
