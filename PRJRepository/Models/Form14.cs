using System;
using System.Collections.Generic;

namespace PRJRepository.Models;

public partial class Form14
{
    public int FormId { get; set; }

    public string? F14Name { get; set; }

    public bool? F14IsSend { get; set; }

    public bool? F14IsReceive { get; set; }

    public bool? F14IsMedicalHistory { get; set; }

    public bool? F14IsMedicalHealth { get; set; }

    public bool? F14IsSocialHistory { get; set; }

    public bool? F14IsEducationalRecord { get; set; }

    public bool? F14IsProgressNotes { get; set; }

    public bool? F14IsScheduling { get; set; }

    public bool? F14IsFinancialInformation { get; set; }

    public bool? F14IsOthers1 { get; set; }

    public string? F14ToFrom { get; set; }

    public string? F14Email { get; set; }

    public string? F14Phone { get; set; }

    public int? F14Relationship { get; set; }

    public bool? F14IsPlanning { get; set; }

    public bool? F14IsContinuing { get; set; }

    public bool? F14IsDetermining { get; set; }

    public bool? F14IsCaseReview { get; set; }

    public bool? F14IsUpdatingFiles { get; set; }

    public bool? F14IsAttendenceReasons { get; set; }

    public bool? F14IsOthers2 { get; set; }
}
