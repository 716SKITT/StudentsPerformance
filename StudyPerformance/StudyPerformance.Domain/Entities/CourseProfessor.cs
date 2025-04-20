namespace StudyPerformance.Domain.Entities;

public class CourseProfessor
{
    public Guid Id { get; private set; }

    public Guid CourseId { get; private set; }

    public Guid ProfessorId { get; private set; }

    private CourseProfessor() { }

    public CourseProfessor(Guid courseId, Guid professorId)
    {
        Id = Guid.NewGuid();
        CourseId = courseId;
        ProfessorId = professorId;
    }
}
