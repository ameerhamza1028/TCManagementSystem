using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Login
{
    public long LoginId { get; set; }

    public int? RoleId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsRememberMe { get; set; }

    public bool? IsTermsAndConditions { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LoginDate { get; set; }
}
