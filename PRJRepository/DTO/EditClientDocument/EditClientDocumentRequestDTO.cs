using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.EditClientDocument
{
    public class EditClientDocumentRequestDTO
    {
        public long EditClientDocumentId { get; set; }

        public long? ClientId { get; set; }

        public string? Title { get; set; }

        public DateTime? Date { get; set; }

        public string? FilePath { get; set; }

        public string? FileName { get; set; }

        public string? Description { get; set; }
    }
}
