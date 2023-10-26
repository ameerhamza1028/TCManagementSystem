using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Login
{
    public class LoginResponseDTO
    {
        public long LoginId { get; set; }
        public string? Token { get; set; }
        public long? UserId { get; set; }
    }
}
