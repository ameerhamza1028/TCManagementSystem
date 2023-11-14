using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Currency
{
    public class GetAllCurrencyRequestDTO
    {
        public int Id { get; set; }

        public string? Code { get; set; }

        public string? Symbol { get; set; }
    }
}
