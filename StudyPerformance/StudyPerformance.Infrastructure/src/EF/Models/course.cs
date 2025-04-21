using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class course
{
    public int courseid { get; set; }

    public string coursename { get; set; } = null!;

    public string? coursedescription { get; set; }

    public int credits { get; set; }

    public virtual ICollection<assignment> assignments { get; set; } = new List<assignment>();

    public virtual ICollection<courseprofessor> courseprofessors { get; set; } = new List<courseprofessor>();

    public virtual ICollection<enrollment> enrollments { get; set; } = new List<enrollment>();

    public virtual ICollection<exam> exams { get; set; } = new List<exam>();
}
