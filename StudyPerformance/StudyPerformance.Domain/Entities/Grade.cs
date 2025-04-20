namespace StudyPerformance.Domain.Entities;

public class Grade
{
    public Guid Id { get; private set; }

    public Guid EnrollmentId { get; private set; }

    public Guid AssignmentId { get; private set; }

    public int PointsEarned { get; private set; }

    private Grade() { }

    public Grade(Guid enrollmentId, Guid assignmentId, int pointsEarned)
    {
        if (pointsEarned < 0)
            throw new ArgumentOutOfRangeException(nameof(pointsEarned), "PointsEarned must be non-negative.");

        Id = Guid.NewGuid();
        EnrollmentId = enrollmentId;
        AssignmentId = assignmentId;
        PointsEarned = pointsEarned;
    }

    public void UpdatePoints(int newPoints)
    {
        if (newPoints < 0)
            throw new ArgumentOutOfRangeException(nameof(newPoints), "Points must be non-negative.");

        PointsEarned = newPoints;
    }
}
