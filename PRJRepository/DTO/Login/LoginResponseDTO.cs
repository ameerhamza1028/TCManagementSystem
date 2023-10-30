using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Login
{
    public class LoginResponseDTO
    {
        public long? LoginId { get; set; }
        public string? Token { get; set; }
        public long? UserId { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }

        public string? CityName { get; set; }

        public string? StateName { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }

        public string? RoleName { get; set; }

        //Client Response

        public long? ClientId { get; set; }

        public long? CoupleId { get; set; }

        public bool? IsAdult { get; set; }

        public bool? IsMinor { get; set; }

        public bool? IsCouple { get; set; }

        public string? FirstName1 { get; set; }

        public string? LastName1 { get; set; }

        public string? Email1 { get; set; }
        
        public string? Phone1 { get; set; }

        public string? FirstName2 { get; set; }

        public string? LastName2 { get; set; }

        public string? Email2 { get; set; }

        public string? Phone2 { get; set; }

    }
}
