﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO
{
    public class GetAllInvoiceRequestDTO
    {
        public long InvoiveId { get; set; }

        public string? InvoiceType { get; set; }
    }
}
