using PRJRepository.DTO.ServiceSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IServiceSettingRepo
    {
        public List<GetAllServiceSettingResponseDTO> GetAllServiceSetting();
        public GetAllServiceSettingRequestDTO GetServiceSettingById(long Id);
        public bool SaveServiceSetting(GetAllServiceSettingRequestDTO request);
        public bool DeleteServiceSetting(long Id);
    }
}
