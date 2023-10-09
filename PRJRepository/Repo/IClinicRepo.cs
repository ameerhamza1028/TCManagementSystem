using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IClinicRepo
    {
        public List<GetAllClinicResponseDTO> GetAllClinic();
        public GetAllClinicResponseDTO GetClinicById(int id);
        public bool SaveClinic(GetAllClinicRequestDTO request);

        public bool DeleteClinic(int id);
    }
}
