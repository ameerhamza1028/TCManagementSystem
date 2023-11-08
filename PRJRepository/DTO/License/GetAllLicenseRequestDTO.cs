using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.License
{
    public class GetAllLicenseRequestDTO
    {
        public List<LicenseRequestDTO>? LicenseRequets { get; set; }
    }
    public class LicenseRequestDTO
    {
        public long? UserId { get; set; }
        public long LicenseId { get; set; }

        public string? LicenseType { get; set; }

        public long? LicenseNumber { get; set; }

        public DateTime? LicenseExpirationDate { get; set; }

        public string? LicenseState { get; set; }

        public long? CreatedBy { get; set; }
    }
}
