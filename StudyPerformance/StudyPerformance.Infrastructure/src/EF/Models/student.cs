using System;
using System.Collections.Generic;

namespace StudyPerformance.Infrastructure.EF.Models;

public partial class student
{
    public int studentid { get; set; }

    public string firstname { get; set; } = null!;

    public string lastname { get; set; } = null!;

    public DateOnly? dateofbirth { get; set; }

    public char? gender { get; set; }

    public string? email { get; set; }

    public string? phonenumber { get; set; }

    public string? address { get; set; }

    public DateOnly enrollmentdate { get; set; }

    public virtual ICollection<academicrecord> academicrecords { get; set; } = new List<academicrecord>();

    public virtual ICollection<enrollment> enrollments { get; set; } = new List<enrollment>();
}
