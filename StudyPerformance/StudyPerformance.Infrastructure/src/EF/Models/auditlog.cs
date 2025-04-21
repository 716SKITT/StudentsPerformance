using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class auditlog
{
    public int auditid { get; set; }

    public string? tablename { get; set; }

    public string? operationtype { get; set; }

    public DateTime? operationtime { get; set; }

    public string? username { get; set; }
}
