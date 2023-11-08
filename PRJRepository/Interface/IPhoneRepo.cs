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
        public List<GetAllPhoneResponseDTO> GetAllPhone(long Id);
        public bool DeletePhone(long Id);
    }
}
