using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IAvailableSlotRepo
    {
        public List<GetAllSlotResponseDTO> GetAllAllAvailableSlot();
        public GetAllSlotResponseDTO GetAvailableSlotById(long Id);
        public bool SaveAvailableSlot(GetAllSlotRequestDTO request);
        public bool DeleteAvailableSlot(long Id);
    }
}
