using PRJRepository.DTO.Client;
using PRJRepository.DTO.EditClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IEditClientRepo
    {
        public List<GetAllEditClientContactResponse> GetAllEditClientContact();
        public EditClientResponseDTO GetEditClient(long Id);

        public SaveEditClientContactResponseDTO GetEditClientContact(long Id);

        public SaveEditClientBillingResponseDTO GetEditClientBilling(long Id);
        public bool SaveClient(SaveEditClientRequestDTO request);
        public bool SaveClientContact(SaveEditClientContactRequestDTO request);

        public bool SaveClientBilling(SaveEditClientBillingRequestDTO request);
    }
}
