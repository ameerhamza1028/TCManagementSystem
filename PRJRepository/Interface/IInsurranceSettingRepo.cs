using PRJRepository.DTO.InsurranceSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IInsurranceSettingRepo
    {
        public List<GetAllInsurranceSettingResponseDTO> GetAllInsurranceSetting();

        public GetAllInsurranceSettingResponseDTO GetInsurranceSettingById(long Id);
        public bool SaveInsurranceSetting(GetAllInsurranceSettingRequestDTO request);
        public bool DeleteInsurranceSetting(long Id);
    }
}
