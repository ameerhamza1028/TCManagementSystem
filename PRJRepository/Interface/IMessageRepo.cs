using PRJRepository.DTO.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IMessageRepo
    {
        public List<GetMessageResponseDTO> GetAllMessage();
        public List<GetMessageResponseDTO> GetMessageById(long Id);
        public bool SaveMessage(GetMessageRequestDTO request);
        public bool DeleteMessage(long Id);
    }
}
