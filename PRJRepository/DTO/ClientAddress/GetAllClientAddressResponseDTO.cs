using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.ClientAddress
{
    public class GetAllClientAddressResponseDTO
    {
        public long AddressId { get; set; }

        public string? Address1 { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? StateId { get; set; }

        public string? ZipCode { get; set; }
    }
}
