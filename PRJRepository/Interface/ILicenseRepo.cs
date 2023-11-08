using PRJRepository.DTO.License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface ILicenseRepo
    {
        public bool DeleteLicense(long Id);
        public List<GetAllLicenseResponseDTO> GetLicenseById(long Id);
    }
}
