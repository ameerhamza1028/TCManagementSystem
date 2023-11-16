using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class ImportClient
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

    public DateTime? CreationDate { get; set; }

    public long? CreatesBy { get; set; }

    public bool? IsActive { get; set; }
}
