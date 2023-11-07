using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.User
{
    public class GetAllUserResponseDTO
    {
        public string? UserName { get; set; }
        public int? UserType { get; set; }

        public long UserId { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int? Status { get; set; }

        public DateTime? CreationDate { get; set; }


    }
}
