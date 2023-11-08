using PRJRepository.DTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IServiceRepo
    {
        public List<GetAllServiceResponseDTO> GetAllService(long Id);
        public bool DeleteService(long Id);
    }
}
