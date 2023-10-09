using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IClinicLocationRepo
    {
        public List<GetAllClinicLocationResponseDTO> GetAllClinicLocation();
        public GetAllClinicLocationResponseDTO GetClinicLocationById(int id);
        public bool SaveClinicLocation(GetAllClinicLocationRequestDTO request);
        public bool DeleteClinicLocation(int id);
    }
}
