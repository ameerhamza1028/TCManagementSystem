using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IOrganizationRepo
    {
        public List<GetAllOrganizationResponseDTO> GetAllOrganization();
        public GetAllOrganizationResponseDTO GetOrganizationById(long Id);

        public bool SaveOrganization(GetAllOrganizationRequestDTO request);

        public bool DeleteOrganization(long Id);
    }
}
