using PRJRepository.DTO.ClinicLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IClinicLocationRepo
    {
        public List<GetAllClinicLocationResponseDTO> GetAllClinicLocation();
        public GetAllClinicLocationResponseDTO GetClinicLocationById(long Id);
        public bool SaveClinicLocation(GetAllClinicLocationRequestDTO request);
        public bool DeleteClinicLocation(long Id);
    }
}
