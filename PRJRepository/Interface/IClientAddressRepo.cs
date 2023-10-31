using PRJRepository.DTO.ClientAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IClientAddressRepo
    {
        public List<GetAllClientAddressResponseDTO> GetAllClientAddress();
        public bool SaveClientAddress(GetAllClientAddressRequestDTO request);
        public bool DeleteClientAddress(long Id);
    }
}
