using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IClientRepo
    {
        public List<GetAllResponseDTO> GetAllClient();
        public GetAllResponseDTO GetClientById(long Id);
        public bool SaveClient(GetAllRequestDTO request);
        public bool DeleteClient(long Id);
    }
}
