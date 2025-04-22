using StudyPerformance.Domain.Entities.Enums;

namespace StudyPerformance.Domain.Entities;
public class Enrollment
{
    public Guid Id { get; private set; }
    public Guid StudentId { get; private set; }
    public Guid CourseId { get; private set; }
    public DateOnly EnrollmentDate { get; private set; }

    public Student Student { get; private set; } = null!;
    public Course Course { get; private set; } = null!;

    private readonly List<Grade> _grades = new();
    public IReadOnlyCollection<Grade> Grades => _grades;

    private readonly List<ExamResult> _examResults = new();
    public IReadOnlyCollection<ExamResult> ExamResults => _examResults;

    private readonly List<Attendance> _attendances = new();
    public IReadOnlyCollection<Attendance> Attendances => _attendances;

    private Enrollment() { }

    public Enrollment(Guid studentId, Guid courseId, DateOnly enrollmentDate)
    {
        Id = Guid.NewGuid();
        StudentId = studentId;
        CourseId = courseId;
        EnrollmentDate = enrollmentDate;
    }

    public void AddGrade(Grade grade) => _grades.Add(grade);
    public void AddExamResult(ExamResult result) => _examResults.Add(result);
    public void AddAttendance(Attendance attendance) => _attendances.Add(attendance);
}
