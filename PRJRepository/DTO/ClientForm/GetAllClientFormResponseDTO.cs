using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.ClientForm
{
    public class GetAllClientFormResponseDTO
    {
        public long FormId { get; set; }

        public long? ClientId { get; set; }
        
        public JsonForm? Form { get; set; }

        public long? FormNumber { get; set; }
    }
}
