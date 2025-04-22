namespace StudyPerformance.Domain.Entities;

public class Grade
{
    public Guid Id { get; private set; }
    public Guid EnrollmentId { get; private set; }
    public Guid AssignmentId { get; private set; }
    public int PointsEarned { get; private set; }

    public Enrollment Enrollment { get; private set; } = null!;
    public Assignment Assignment { get; private set; } = null!;

    private Grade() { }

    public Grade(Guid enrollmentId, Guid assignmentId, int pointsEarned)
    {
        Id = Guid.NewGuid();
        EnrollmentId = enrollmentId;
        AssignmentId = assignmentId;
        PointsEarned = pointsEarned;
    }

    public void UpdatePoints(int newPoints)
    {
        if (newPoints < 0)
            throw new ArgumentOutOfRangeException(nameof(newPoints));
        PointsEarned = newPoints;
    }
}
