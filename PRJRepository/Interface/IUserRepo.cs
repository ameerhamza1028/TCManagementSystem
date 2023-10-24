using PRJRepository.DTO;
using PRJRepository.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IUserRepo
    {
        public List<GetAllUserResponseDTO> GetAllUser();
        public bool SaveUser(GetAllUserRequestDTO request);
    }
}
