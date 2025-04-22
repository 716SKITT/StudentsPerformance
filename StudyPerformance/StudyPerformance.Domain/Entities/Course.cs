namespace StudyPerformance.Domain.Entities;

public class Course
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public int Credits { get; private set; }

    private readonly List<Assignment> _assignments = new();
    public ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();
    public ICollection<Assignment> Assignments { get; private set; } = new List<Assignment>();
    public ICollection<Exam> Exams { get; private set; } = new List<Exam>();
    public ICollection<CourseProfessor> CourseProfessors { get; private set; } = new List<CourseProfessor>();
    public ICollection<AcademicRecord> AcademicRecords { get; private set; } = new List<AcademicRecord>();


    private Course() { }

    public Course(string name, int credits, string? description = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Credits = credits;
        Description = description;
    }

    public void AddAssignment(Assignment assignment)
    {
        _assignments.Add(assignment);
    }

    public void UpdateDetails(string name, string? description, int credits)
    {
        Name = name;
        Description = description;
        Credits = credits;
    }
}
