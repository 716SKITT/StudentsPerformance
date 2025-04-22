namespace StudyPerformance.Domain.Entities;

public class ExamResult
{
    public Guid Id { get; private set; }
    public Guid EnrollmentId { get; private set; }
    public Guid ExamId { get; private set; }
    public int Score { get; private set; }

    public Enrollment Enrollment { get; private set; } = null!;
    public Exam Exam { get; private set; } = null!;

    private ExamResult() { }

    public ExamResult(Guid enrollmentId, Guid examId, int score)
    {
        if (score < 0)
            throw new ArgumentOutOfRangeException(nameof(score));

        Id = Guid.NewGuid();
        EnrollmentId = enrollmentId;
        ExamId = examId;
        Score = score;
    }

    public void UpdateScore(int newScore)
    {
        if (newScore < 0)
            throw new ArgumentOutOfRangeException(nameof(newScore));

        Score = newScore;
    }
}
