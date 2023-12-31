﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Invoice
{
    public class GetAllInvoiceResponseDTO
    {
        public long InvoiveId { get; set; }

        public string? InvoiceType { get; set; }

        public DateTime? CreationDate { get; set; }

        public long? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
