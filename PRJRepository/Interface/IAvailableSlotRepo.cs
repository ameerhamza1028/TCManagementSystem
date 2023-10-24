using PRJRepository.DTO.AvailableSlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IAvailableSlotRepo
    {
        public List<GetAllSlotAvailableResponseDTO> GetAllAllAvailableSlot();
        public GetAllSlotAvailableResponseDTO GetAvailableSlotById(long Id);
        public bool SaveAvailableSlot(GetAllAvailableSlotRequestDTO request);
        public bool DeleteAvailableSlot(long Id);
    }
}
