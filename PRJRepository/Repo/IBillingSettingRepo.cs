using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IBillingSettingRepo
    {
        public List<GetAllBillingSettingResponseDTO> GetAllBillingSetting();
        public GetAllBillingSettingResponseDTO GetBillingSettingById(int id);
        public bool SaveBillingSetting(GetAllBillingSettingRequestDTO request);
        public bool DeleteBillingSetting(int id);
    }
}
