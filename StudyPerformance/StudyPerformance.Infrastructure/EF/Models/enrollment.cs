using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class enrollment
{
    public int enrollmentid { get; set; }

    public int? studentid { get; set; }

    public int? courseid { get; set; }

    public DateOnly enrollmentdate { get; set; }

    public virtual ICollection<attendance> attendances { get; set; } = new List<attendance>();

    public virtual course? course { get; set; }

    public virtual ICollection<examresult> examresults { get; set; } = new List<examresult>();

    public virtual ICollection<grade> grades { get; set; } = new List<grade>();

    public virtual student? student { get; set; }
}
