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
        public List<GetAllResponseDTO> GetAllUser();
        public GetAllResponseDTO GetUserById(int id);
        public bool SaveUser(GetAllRequestDTO request);
        public bool DeleteUser(int id);
    }
}
