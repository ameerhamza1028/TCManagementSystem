using AutoMapper;
using PRJRepository.DTO.CPTCode;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class CPTCodeRepo : ICPTCodeRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public CPTCodeRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetAllCPTCodeResponseDTO> GetAllCPTCode()
        {
            List<GetAllCPTCodeResponseDTO> response = new List<GetAllCPTCodeResponseDTO>();
            List<Models.Cptcode> list = _context.Cptcodes.ToList();
            response = _mapper.Map<List<GetAllCPTCodeResponseDTO>>(list);
            return response;
        }
    }
}
