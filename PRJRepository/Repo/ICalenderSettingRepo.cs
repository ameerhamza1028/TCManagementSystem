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

        public GetAllCalenderSettingResponseDTO GetCalenderSettingById(long Id);
        public bool SaveCalenderSetting(GetAllCalenderSettingRequestDTO request);
        public bool DeleteCalenderSetting(long Id);
    }
}
