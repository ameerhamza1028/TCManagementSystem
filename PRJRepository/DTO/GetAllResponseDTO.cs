using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO
{
     public class GetAllResponseDTO
    {
        public int ClientId { get; set; }

        public string? ClientType { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public bool? IsSendEmailReminder { get; set; }

        public bool? IsSendTextReminder { get; set; }

        public string? Phone { get; set; }

        public string? BilingType { get; set; }

        public long? PrimaryClinicId { get; set; }

        public long? LocationId { get; set; }
    }
}
