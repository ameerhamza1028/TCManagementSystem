using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Phone
{
    public class GetAllPhoneResponseDTO
    {
        public long PhoneId { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PhoneType { get; set; }

        public bool? IsSendTextMessage { get; set; }

        public bool? IsSendVoiceMessage { get; set; }

        public long? ContactId { get; set; }

        public int? CouplePhoneId { get; set; }
    }
}
