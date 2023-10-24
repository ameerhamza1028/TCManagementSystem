﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.ClientForm
{
    public class GetAllClientFormResponseDTO
    {
        public long FormId { get; set; }

        public long? ClientId { get; set; }

        public string? FormJson { get; set; }

        public long? FormNumber { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}