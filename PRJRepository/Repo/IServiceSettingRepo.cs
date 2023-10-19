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
<<<<<<< HEAD
        public GetAllServiceSettingResponseDTO GetServiceSettingById(long Id);
        public bool SaveServiceSetting(GetAllServiceSettingRequestDTO request);
        public bool DeleteServiceSetting(long Id);
=======
        public GetAllServiceSettingResponseDTO GetServiceSettingById(int id);
        public bool SaveServiceSetting(GetAllServiceSettingRequestDTO request);
        public bool DeleteServiceSetting(int id);
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
    }
}
