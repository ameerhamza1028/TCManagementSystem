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
        public class Form8Repo : IForm8Repo
        {
            private readonly TcdatabaseContext _context;
            private readonly IMapper _mapper;
            public Form8Repo(TcdatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public bool SaveForm8(GetAllForm8RequestDTO request)
            {
                try
                {
                    Form8 tcForm8 = new Form8();
                    if (request.FormId == 0)
                    {
                        tcForm8 = _mapper.Map<Form8>(request);
                        _context.Form8s.Add(tcForm8);
                        _context.SaveChanges();
                    }
                    else
                    {
                        tcForm8 = _context.Form8s.Where(x => x.FormId == request.FormId).FirstOrDefault();
                        tcForm8 = _mapper.Map(request, tcForm8);
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
