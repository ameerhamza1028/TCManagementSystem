using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IUserRepo
    {
        public List<GetAllUserResponseDTO> GetAllUser();
        public bool SaveUser(GetAllUserRequestDTO request);
    }
}
