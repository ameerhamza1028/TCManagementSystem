using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Message
{
    public class GetMessageRequestDTO
    {
        public long MessageId { get; set; }

        public long? MessageSenderId { get; set; }

        public long? MessageReceiverId { get; set; }

        public string? Message1 { get; set; }

    }
}
