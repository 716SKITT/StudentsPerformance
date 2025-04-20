namespace StudyPerformance.Domain.Entities;

public class Course
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public int Credits { get; private set; }

    private Course() { }

    public Course(string name, int credits, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Course name is required.", nameof(name));

        if (credits <= 0)
            throw new ArgumentOutOfRangeException(nameof(credits), "Credits must be greater than zero.");

        Id = Guid.NewGuid();
        Name = name;
        Credits = credits;
        Description = description;
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
    }

    public void UpdateCredits(int credits)
    {
        if (credits <= 0)
            throw new ArgumentOutOfRangeException(nameof(credits), "Credits must be greater than zero.");

        Credits = credits;
    }
}
