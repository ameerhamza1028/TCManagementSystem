using PRJRepository.DTO.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IPhoneRepo
    {
        public List<GetAllPhoneResponseDTO> GetAllPhone();
        public bool SavePhone(GetAllPhoneRequestDTO request);
        public bool DeletePhone(long Id);
    }
}
