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
<<<<<<< HEAD
        public GetAllBillingSettingResponseDTO GetBillingSettingById(long Id);
        public bool SaveBillingSetting(GetAllBillingSettingRequestDTO request);
        public bool DeleteBillingSetting(long Id);
=======
        public GetAllBillingSettingResponseDTO GetBillingSettingById(int id);
        public bool SaveBillingSetting(GetAllBillingSettingRequestDTO request);
        public bool DeleteBillingSetting(int id);
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
    }
}
