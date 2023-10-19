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
    public class Form2Repo : IForm2Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form2Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm2(GetAllForm2RequestDTO request)
        {
            try
            {
                Form2 tcForm2 = new Form2();
                if (request.FormId == 0)
                {
                    tcForm2 = _mapper.Map<Form2>(request);
                    _context.Form2s.Add(tcForm2);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm2 = _context.Form2s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm2 = _mapper.Map(request, tcForm2);
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
