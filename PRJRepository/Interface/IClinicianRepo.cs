using PRJRepository.DTO.Clinician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IClinicianRepo
    {
        public List<GetAllClinicianResponseDTO> GetAllClinician();
    }
}
