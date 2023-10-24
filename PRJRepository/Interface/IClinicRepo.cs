using PRJRepository.DTO.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IClinicRepo
    {
        public List<GetAllClinicResponseDTO> GetAllClinic();
        public GetAllClinicResponseDTO GetClinicById(long Id);
        public bool SaveClinic(GetAllClinicRequestDTO request);

        public bool DeleteClinic(long Id);
    }
}
