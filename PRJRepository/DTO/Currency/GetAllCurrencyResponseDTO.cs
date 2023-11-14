using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Currency
{
    public class GetAllCurrencyResponseDTO
    {
        public int id { get; set; }

        public string? code { get; set; }

        public string? symbol { get; set; }
    }
}
