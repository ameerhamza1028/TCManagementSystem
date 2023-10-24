using PRJRepository.DTO.CalenderSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface ICalenderSettingRepo
    {
        public List<GetAllCalenderSettingResponseDTO> GetAllCalenderSetting();

        public GetAllCalenderSettingResponseDTO GetCalenderSettingById(long Id);
        public bool SaveCalenderSetting(GetAllCalenderSettingRequestDTO request);
        public bool DeleteCalenderSetting(long Id);
    }
}
