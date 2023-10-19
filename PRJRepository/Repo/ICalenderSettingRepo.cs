using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface ICalenderSettingRepo
    {
        public List<GetAllCalenderSettingResponseDTO> GetAllCalenderSetting();
<<<<<<< HEAD
        public GetAllCalenderSettingResponseDTO GetCalenderSettingById(long Id);
        public bool SaveCalenderSetting(GetAllCalenderSettingRequestDTO request);
        public bool DeleteCalenderSetting(long Id);
=======
        public GetAllCalenderSettingResponseDTO GetCalenderSettingById(int id);
        public bool SaveCalenderSetting(GetAllCalenderSettingRequestDTO request);
        public bool DeleteCalenderSetting(int id);
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
    }
}
