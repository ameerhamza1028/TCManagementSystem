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
    public class Form1Repo : IForm1Repo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public Form1Repo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveForm1(GetAllForm1RequestDTO request)
        {
            try
            {
                Form1 tcForm1 = new Form1();
                if (request.FormId == 0)
                {
                    tcForm1 = _mapper.Map<Form1>(request);
                    _context.Form1s.Add(tcForm1);
                    _context.SaveChanges();
                }
                else
                {
                    tcForm1 = _context.Form1s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    tcForm1 = _mapper.Map(request, tcForm1);
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
