using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Card
{
    public class GetAllCardResponseDTO
    {
        public long CardId { get; set; }

        public long? CardNumber { get; set; }

        public DateTime? DateExpire { get; set; }

        public string? CardType { get; set; }

        public bool? IsSetDefault { get; set; }

        public long? CreatedBy { get; set; }

    }
}
