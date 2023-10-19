using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IInsurranceSettingRepo
    {
        public List<GetAllInsurranceSettingResponseDTO> GetAllInsurranceSetting();
<<<<<<< HEAD
        public GetAllInsurranceSettingResponseDTO GetInsurranceSettingById(long Id);
        public bool SaveInsurranceSetting(GetAllInsurranceSettingRequestDTO request);
        public bool DeleteInsurranceSetting(long Id);
=======
        public GetAllInsurranceSettingResponseDTO GetInsurranceSettingById(int id);
        public bool SaveInsurranceSetting(GetAllInsurranceSettingRequestDTO request);
        public bool DeleteInsurranceSetting(int id);
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
    }
}
