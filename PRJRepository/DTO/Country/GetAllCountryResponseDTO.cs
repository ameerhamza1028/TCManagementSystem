using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Country
{
    public class GetAllCountryResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
