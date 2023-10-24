using PRJRepository.DTO.CheckAvailability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface ICheckAvailabilityRepo
    {
        public GetAllCheckAvailabilityResponseDTO GetCheckAvailability(GetAllCheckAvailabilityRequestDTO request);
    }
}
