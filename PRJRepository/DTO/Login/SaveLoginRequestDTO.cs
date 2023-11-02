using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Login
{
    public class SaveLoginRequestDTO
    {
        public long LoginId { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
    }
}
