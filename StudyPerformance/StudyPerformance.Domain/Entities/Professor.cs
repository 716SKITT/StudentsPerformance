namespace StudyPerformance.Domain.Entities;

public class Professor
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Department { get; private set; }

    private readonly List<CourseProfessor> _courseProfessors = new();
    public IReadOnlyCollection<CourseProfessor> CourseProfessors => _courseProfessors;

    private Professor() { }

    public Professor(string firstName, string lastName, string? email = null, string? phone = null, string? department = null)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phone;
        Department = department;
    }

    public void UpdateContact(string email, string phone)
    {
        Email = email;
        PhoneNumber = phone;
    }

    public void UpdateDepartment(string department)
    {
        Department = department;
    }

    public void AddCourseLink(CourseProfessor link)
    {
        _courseProfessors.Add(link);
    }
}
