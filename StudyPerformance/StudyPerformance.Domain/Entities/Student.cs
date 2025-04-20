namespace StudyPerformance.Domain.Entities;

public class Student
{
    public Guid Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public DateOnly? DateOfBirth { get; private set; }

    public string? Gender { get; private set; }

    public string? Email { get; private set; }

    public string? PhoneNumber { get; private set; }

    public string? Address { get; private set; }

    public DateOnly EnrollmentDate { get; private set; }

    private readonly List<Enrollment> _enrollments = new();
    public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

    private Student() { }

    public Student(string firstName, string lastName, DateOnly enrollmentDate, DateOnly? dateOfBirth = null, string? gender = null)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        EnrollmentDate = enrollmentDate;
        DateOfBirth = dateOfBirth;
        Gender = gender;
    }

    public void UpdateContact(string? email, string? phone)
    {
        Email = email;
        PhoneNumber = phone;
    }

    public void UpdateAddress(string? address)
    {
        Address = address;
    }

    public void AddEnrollment(Enrollment enrollment)
    {
        if (enrollment == null) throw new ArgumentNullException(nameof(enrollment));
        _enrollments.Add(enrollment);
    }
}
