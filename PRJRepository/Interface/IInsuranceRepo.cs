using PRJRepository.DTO.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IInsuranceRepo
    {
        public List<GetAllInsuranceResponseDTO> GetAllInsurance();
        public bool SaveInsurance(GetAllInsuranceRequestDTO request);
        public bool DeleteInsurance(long Id);
    }
}
