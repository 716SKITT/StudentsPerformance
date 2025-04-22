namespace StudyPerformance.Domain.Entities;

public class AcademicRecord
{
    public Guid Id { get; private set; }
    public Guid StudentId { get; private set; }
    public decimal GPA { get; private set; }
    public int AcademicYear { get; private set; }
    public int Semester { get; private set; }

    public Student Student { get; private set; } = null!;

    private AcademicRecord() { }

    public AcademicRecord(Guid studentId, decimal gpa, int academicYear, int semester)
    {
        if (gpa < 0 || gpa > 5.0m)
            throw new ArgumentOutOfRangeException(nameof(gpa), "GPA must be between 0 and 5.0");

        Id = Guid.NewGuid();
        StudentId = studentId;
        GPA = gpa;
        AcademicYear = academicYear;
        Semester = semester;
    }

    public void UpdateGpa(decimal gpa)
    {
        if (gpa < 0 || gpa > 5.0m)
            throw new ArgumentOutOfRangeException(nameof(gpa), "GPA must be between 0 and 5.0");

        GPA = gpa;
    }
}
