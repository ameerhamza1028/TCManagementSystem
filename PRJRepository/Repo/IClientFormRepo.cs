using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IClientFormRepo
    {
        public GetAllClientFormResponseDTO GetClientFormById(long Id);
        public bool SaveClientForm(GetAllClientFormRequestDTO request);
    }
}
