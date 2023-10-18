using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IInvoiceRepo
    {
        public List<GetAllInvoiceResponseDTO> GetAllInvoice();
        public GetAllInvoiceResponseDTO GetInvoiceById(long Id);
        public bool SaveInvoice(GetAllInvoiceRequestDTO request);
        public bool DeleteInvoice(long Id);
    }
}
