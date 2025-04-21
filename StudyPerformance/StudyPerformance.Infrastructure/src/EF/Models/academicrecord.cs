using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class academicrecord
{
    public int recordid { get; set; }

    public int? studentid { get; set; }

    public decimal gpa { get; set; }

    public int academicyear { get; set; }

    public int semester { get; set; }

    public virtual student? student { get; set; }
}
