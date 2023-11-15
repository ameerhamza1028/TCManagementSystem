using PRJRepository.DTO.CPTCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface ICPTCodeRepo
    {
        public List<GetAllCPTCodeResponseDTO> GetAllCPTCode();
    }
}
