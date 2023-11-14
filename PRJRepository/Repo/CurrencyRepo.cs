using AutoMapper;
using PRJRepository.DTO.Currency;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class CurrencyRepo : ICurrencyRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public CurrencyRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetAllCurrencyResponseDTO> GetAllCurrency()
        {
            List<GetAllCurrencyResponseDTO> response = new List<GetAllCurrencyResponseDTO>();
            List<Models.Currency> list = _context.Currencies.ToList();
            response = _mapper.Map<List<GetAllCurrencyResponseDTO>>(list);
            return response;
        }
    }
}
