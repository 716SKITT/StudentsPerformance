using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class assignment
{
    public int assignmentid { get; set; }

    public int? courseid { get; set; }

    public string assignmentname { get; set; } = null!;

    public string? description { get; set; }

    public DateOnly duedate { get; set; }

    public int maxpoints { get; set; }

    public virtual course? course { get; set; }

    public virtual ICollection<grade> grades { get; set; } = new List<grade>();
}
