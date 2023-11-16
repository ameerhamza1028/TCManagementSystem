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
        public List<GetAllServiceResponseDTO> GetAllServiceNames();
        public List<GetAllServiceSettingResponseDTO> GetAllServiceSetting(long Id);
        public EditServiceSettingResponseDTO GetServiceSettingById(long Id);
        public bool SaveServiceSetting(GetAllServiceSettingRequestDTO request);
        public bool DeleteServiceSetting(long Id);
        public List<GetAllClinicianServiceResponseDTO> GetClinicianServices(long Id);
    }
}
