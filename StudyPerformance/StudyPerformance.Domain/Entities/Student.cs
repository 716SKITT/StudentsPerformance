namespace StudyPerformance.Domain.Entities;

public class Student
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public string? Gender { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Address { get; private set; }
    public DateOnly EnrollmentDate { get; private set; }

    private readonly List<Enrollment> _enrollments = new();
    public ICollection<AcademicRecord> AcademicRecords { get; private set; } = new List<AcademicRecord>();
    public IReadOnlyCollection<Enrollment> Enrollments => _enrollments;

    private Student() { }

    public Student(string firstName, string lastName, DateOnly dateOfBirth)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        EnrollmentDate = DateOnly.FromDateTime(DateTime.UtcNow);
    }

    public void UpdateContact(string email, string phone)
    {
        Email = email;
        PhoneNumber = phone;
    }

    public void UpdateAddress(string address)
    {
        Address = address;
    }

    public void AddEnrollment(Enrollment enrollment)
    {
        _enrollments.Add(enrollment);
    }
}
