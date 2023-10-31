using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Email
{
    public class GetAllEmailResponseDTO
    {
        public long EmailId { get; set; }

        public string? EmailAddress { get; set; }

        public string? EmailType { get; set; }

        public bool? IsEmailOk { get; set; }

        public bool? IsAccessToClientPortal { get; set; }

        public long? CreatedBy { get; set; }
    }
}
