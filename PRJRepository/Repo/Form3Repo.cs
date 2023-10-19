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
    public class Form3Repo : IForm3Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form3Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm3(GetAllForm3RequestDTO request)
        {
            try
            {
                Form3 tcForm3 = new Form3();
                if (request.FormId == 0)
                {
                    tcForm3 = _mapper.Map<Form3>(request);
                    _context.Form3s.Add(tcForm3);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm3 = _context.Form3s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm3 = _mapper.Map(request, tcForm3);
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
