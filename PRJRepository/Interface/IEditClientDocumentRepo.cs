using PRJRepository.DTO.EditClientDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IEditClientDocumentRepo
    {
        public List<EditClientDocumentResponseDTO> GetAllEditClientDocument(long Id);
        public EditClientDocumentRequestDTO GetEditClientDocumentById(long Id);
        public bool SaveEditClientDocument(EditClientDocumentRequestDTO request);
        public bool DeleteEditClientDocument(long Id);
    }
}
