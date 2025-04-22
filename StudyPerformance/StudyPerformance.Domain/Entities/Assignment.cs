namespace StudyPerformance.Domain.Entities;

public class Assignment
{
    public Guid Id { get; private set; }
    public Guid CourseId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public DateOnly DueDate { get; private set; }
    public int MaxPoints { get; private set; }
    public Course Course { get; private set; } = null!;

    private readonly List<Grade> _grades = new();
    public IReadOnlyCollection<Grade> Grades => _grades;

    private Assignment() { }

    public Assignment(Guid courseId, string name, DateOnly dueDate, int maxPoints, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Assignment name is required.", nameof(name));

        if (maxPoints <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxPoints), "MaxPoints must be greater than 0.");

        CourseId = courseId;
        Id = Guid.NewGuid();
        Name = name;
        DueDate = dueDate;
        MaxPoints = maxPoints;
        Description = description;
    }

    public void UpdateDetails(string name, DateOnly dueDate, int maxPoints, string? description = null)
    {
        Name = name;
        DueDate = dueDate;
        MaxPoints = maxPoints;
        Description = description;
    }

    public void AddGrade(Grade grade) => _grades.Add(grade);
}
