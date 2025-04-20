using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class attendance
{
    public int attendanceid { get; set; }

    public int? enrollmentid { get; set; }

    public DateOnly attendancedate { get; set; }

    public char? status { get; set; }

    public virtual enrollment? enrollment { get; set; }
}
