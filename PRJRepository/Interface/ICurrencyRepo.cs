using PRJRepository.DTO.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface ICurrencyRepo
    {
        public List<GetAllCurrencyResponseDTO> GetAllCurrency();
    }
}
