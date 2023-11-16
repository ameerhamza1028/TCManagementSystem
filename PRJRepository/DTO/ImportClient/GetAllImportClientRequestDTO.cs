using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.ImportClient
{
    public class GetAllImportClientRequestDTO
    {
        public long ImportClientId { get; set; }

        public string? FileUploadPath { get; set; }

        public string? FileName { get; set; }

        public int? ActiveClient { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? NickName { get; set; }

        public int? PrimaryClinicianId { get; set; }

        public string? MobilePhone { get; set; }

        public string? ClientEmail { get; set; }

        public int? Intake { get; set; }
    }
}
