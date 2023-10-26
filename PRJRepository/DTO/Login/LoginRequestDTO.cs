using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Login
{
    public class LoginRequestDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsRememberMe { get; set; }
        public bool? IsTermsAndConditions { get; set; }
    }
}
