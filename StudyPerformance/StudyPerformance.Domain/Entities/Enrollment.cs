namespace StudyPerformance.Domain.Entities;

public class Enrollment
{
    public Guid Id { get; private set; }

    public Guid StudentId { get; private set; }

    public Guid CourseId { get; private set; }

    public DateOnly EnrollmentDate { get; private set; }

    public EnrollmentStatus Status { get; private set; } = EnrollmentStatus.Active;

    private Enrollment() { }

    public Enrollment(Guid studentId, Guid courseId, DateOnly enrollmentDate)
    {
        Id = Guid.NewGuid();
        StudentId = studentId;
        CourseId = courseId;
        EnrollmentDate = enrollmentDate;
    }

    public void MarkAsWithdrawn()
    {
        if (Status == EnrollmentStatus.Withdrawn)
            throw new InvalidOperationException("Enrollment already withdrawn.");

        Status = EnrollmentStatus.Withdrawn;
    }

    public void MarkAsCompleted()
    {
        if (Status != EnrollmentStatus.Active)
            throw new InvalidOperationException("Only active enrollments can be completed.");

        Status = EnrollmentStatus.Completed;
    }
}
