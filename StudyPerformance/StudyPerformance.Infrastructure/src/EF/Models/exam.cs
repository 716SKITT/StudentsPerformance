using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class exam
{
    public int examid { get; set; }

    public int? courseid { get; set; }

    public string examname { get; set; } = null!;

    public DateOnly examdate { get; set; }

    public int maxscore { get; set; }

    public virtual course? course { get; set; }

    public virtual ICollection<examresult> examresults { get; set; } = new List<examresult>();
}
