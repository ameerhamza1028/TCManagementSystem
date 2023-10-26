using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Invoice
{
    public class GetAllInvoiceRequestDTO
    {
        public long InvoiveId { get; set; }

        public string? InvoiceType { get; set; }

        public long? CreatedBy { get; set; }

    }
}
