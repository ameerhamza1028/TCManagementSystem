using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Organization
{
    public class GetAllOrganizationResponseDTO
    {
        public long OrgId { get; set; }

        public string? OrgName { get; set; }

        public string? OrgAddress { get; set; }

        public string? OrgDescription { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreationDate { get; set; }

        public long? CreatedBy { get; set; }
    }
}
