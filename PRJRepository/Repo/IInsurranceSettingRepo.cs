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
        public GetAllInsurranceSettingResponseDTO GetInsurranceSettingById(int id);
        public bool SaveInsurranceSetting(GetAllInsurranceSettingRequestDTO request);
        public bool DeleteInsurranceSetting(int id);
    }
}
