using PRJRepository.DTO.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IEmailRepo
    {
        public List<GetAllEmailResponseDTO> GetAllEmail();
        public bool SaveEmail(GetAllEmailRequestDTO request);
        public bool DeleteEmail(long Id);
    }
}
