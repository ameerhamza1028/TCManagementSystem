using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO
{
    public class GetAllOrganizationRequestDTO
    {
        public int OrgId { get; set; }
        public string? OrgName { get; set; }

        public string? OrgLogo { get; set; }

        public string? OrgAddress { get; set; }

        public string? OrgDescription { get; set; }
    }
}
