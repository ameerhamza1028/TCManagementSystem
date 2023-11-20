using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class EditClientDocument
{
    public long EditClientDocumentId { get; set; }

    public long? ClientId { get; set; }

    public string? Title { get; set; }

    public DateTime? Date { get; set; }

    public string? FilePath { get; set; }

    public string? FileName { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }
}
