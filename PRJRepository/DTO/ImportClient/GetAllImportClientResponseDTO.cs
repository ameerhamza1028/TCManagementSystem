using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.ImportClient
{
    public class GetAllImportClientResponseDTO
    {
        public long ImportClientId { get; set; }

        public string? FileName { get; set; }

        public string? FilePath { get; set; }

        public string? Name { get; set; }

        public string? Clinician { get; set; }

        public string? ClientEmail { get; set; }

        public int? Intake { get; set; }

        public DateTime? DateAdded { get; set; }
    }
}
