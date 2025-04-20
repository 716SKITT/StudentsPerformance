namespace StudyPerformance.Domain.Entities;

public class ExamResult
{
    public Guid Id { get; private set; }

    public Guid EnrollmentId { get; private set; }

    public Guid ExamId { get; private set; }

    public int Score { get; private set; }

    private ExamResult() { }

    public ExamResult(Guid enrollmentId, Guid examId, int score)
    {
        if (score < 0 || score > 100)
            throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 100");

        Id = Guid.NewGuid();
        EnrollmentId = enrollmentId;
        ExamId = examId;
        Score = score;
    }

    public void UpdateScore(int score)
    {
        if (score < 0 || score > 100)
            throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 100");

        Score = score;
    }
}
