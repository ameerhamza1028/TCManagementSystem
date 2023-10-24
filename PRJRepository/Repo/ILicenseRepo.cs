using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface ILicenseRepo
    {
        public List<GetAllLicenseResponseDTO> GetAllLicense();
        public bool SaveLicense(GetAllLicenseRequestDTO request);
        public bool DeleteLicense(long Id);
    }
}
