using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class User
{
    public string? UserType { get; set; }

    public long UserId { get; set; }

    public string? UserName { get; set; }

    public string? AddressType { get; set; }

    public string? Address { get; set; }

    public string? CityName { get; set; }

    public string? StateName { get; set; }

    public long? ZipCode { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Month { get; set; }

    public int? Day { get; set; }

    public long? Year { get; set; }

    public long? Npi { get; set; }

    public long? TaxId { get; set; }

    public string? Status { get; set; }

    public string? PrimaryWorkLocation { get; set; }

    public string? Malpractice { get; set; }

    public long? MalpracticePolicy { get; set; }

    public DateTime? MalpracticeExpDate { get; set; }

    public string? UploadFilePath { get; set; }

    public string? School { get; set; }

    public string? DegreeReceived { get; set; }

    public long? Caqhid { get; set; }

    public string? DefaultModifier { get; set; }

    public long? LicenseId { get; set; }

    public long? TaxonomyCode { get; set; }

    public string? Modifier1 { get; set; }

    public string? Modifier2 { get; set; }

    public string? Modifier3 { get; set; }

    public DateTime? CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }
}
