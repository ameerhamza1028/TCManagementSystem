using PRJRepository.DTO.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IClientRepo
    {
        public List<GetAllClientResponseDTO> GetAllClient();
        public EditClientResponseDTO GetClientById(long Id);
        public bool SaveClient(GetAllClientRequestDTO request);
        public bool DeleteClient(long Id);
    }
}
