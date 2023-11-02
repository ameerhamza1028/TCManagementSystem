using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Login
{
    public interface LoginOTPRequestDTO
    {
        public string? Otpcode { get; set; }
    }
}
