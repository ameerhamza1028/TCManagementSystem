using PRJRepository.DTO.BillingSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IBillingSettingRepo
    {
        public List<GetAllBillingSettingResponseDTO> GetAllBillingSetting();
        public GetAllBillingSettingResponseDTO GetBillingSettingById(long Id);
        public bool SaveBillingSetting(GetAllBillingSettingRequestDTO request);
        public bool DeleteBillingSetting(long Id);
    }
}
