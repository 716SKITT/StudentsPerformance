using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class professor
{
    public int professorid { get; set; }

    public string firstname { get; set; } = null!;

    public string lastname { get; set; } = null!;

    public string? email { get; set; }

    public string? phonenumber { get; set; }

    public string? department { get; set; }

    public virtual ICollection<courseprofessor> courseprofessors { get; set; } = new List<courseprofessor>();
}
