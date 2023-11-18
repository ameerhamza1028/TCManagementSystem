using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class ClientNote
{
    public long NoteId { get; set; }

    public long? ClientId { get; set; }

    public string? NoteTitle { get; set; }

    public string? Note { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreactionDate { get; set; }

    public long? CreatedBy { get; set; }
}
