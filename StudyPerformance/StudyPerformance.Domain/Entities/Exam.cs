namespace StudyPerformance.Domain.Entities;

public class Exam
{
    public Guid Id { get; private set; }

    public Guid CourseId { get; private set; }

    public string Name { get; private set; }

    public DateOnly ExamDate { get; private set; }

    public int MaxScore { get; private set; }

    private Exam() { }

    public Exam(Guid courseId, string name, DateOnly examDate, int maxScore)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Exam name is required.", nameof(name));

        if (maxScore <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxScore), "MaxScore must be greater than zero.");

        Id = Guid.NewGuid();
        CourseId = courseId;
        Name = name;
        ExamDate = examDate;
        MaxScore = maxScore;
    }

    public void Reschedule(DateOnly newDate)
    {
        if (newDate < DateOnly.FromDateTime(DateTime.Today))
            throw new ArgumentException("New exam date cannot be in the past.", nameof(newDate));

        ExamDate = newDate;
    }

    public void UpdateMaxScore(int newMaxScore)
    {
        if (newMaxScore <= 0)
            throw new ArgumentOutOfRangeException(nameof(newMaxScore), "MaxScore must be greater than zero.");

        MaxScore = newMaxScore;
    }
}
