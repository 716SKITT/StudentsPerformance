using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class examresult
{
    public int examresultid { get; set; }

    public int? enrollmentid { get; set; }

    public int? examid { get; set; }

    public int score { get; set; }

    public virtual enrollment? enrollment { get; set; }

    public virtual exam? exam { get; set; }
}
