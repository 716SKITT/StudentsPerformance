using StudyPerformance.Domain.Entities.Enums;
namespace StudyPerformance.Domain.Entities;

public class Attendance
{
    public Guid Id { get; private set; }
    public Guid EnrollmentId { get; private set; }
    public DateOnly AttendanceDate { get; private set; }
    public AttendanceStatus Status { get; private set; }

    public Enrollment Enrollment { get; private set; } = null!;

    private Attendance() { }

    public Attendance(Guid enrollmentId, DateOnly attendanceDate, AttendanceStatus status)
    {
        Id = Guid.NewGuid();
        EnrollmentId = enrollmentId;
        AttendanceDate = attendanceDate;
        Status = status;
    }

    public void MarkPresent() => Status = AttendanceStatus.Present;

    public void MarkAbsent() => Status = AttendanceStatus.Absent;
}
