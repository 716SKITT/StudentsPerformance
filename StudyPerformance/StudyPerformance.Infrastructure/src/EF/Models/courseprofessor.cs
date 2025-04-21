using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class courseprofessor
{
    public int courseprofessorid { get; set; }

    public int? courseid { get; set; }

    public int? professorid { get; set; }

    public virtual course? course { get; set; }

    public virtual professor? professor { get; set; }
}
