using PRJRepository.DTO.ClientForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IClientFormRepo
    {
        public GetAllClientFormResponseDTO GetClientFormById(long Id);
        public bool SaveClientForm(GetAllClientFormRequestDTO request);
    }
}
