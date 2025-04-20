using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class grade
{
    public int gradeid { get; set; }

    public int? enrollmentid { get; set; }

    public int? assignmentid { get; set; }

    public int pointsearned { get; set; }

    public virtual assignment? assignment { get; set; }

    public virtual enrollment? enrollment { get; set; }
}
