using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IServiceSettingRepo
    {
        public List<GetAllServiceSettingResponseDTO> GetAllServiceSetting();
        public GetAllServiceSettingResponseDTO GetServiceSettingById(long Id);
        public bool SaveServiceSetting(GetAllServiceSettingRequestDTO request);
        public bool DeleteServiceSetting(long Id);
    }
}
