using PRJRepository.DTO.EditClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IEditClientRepo
    {
        public bool SaveClient(SaveEditClientRequestDTO request);
    }
}
