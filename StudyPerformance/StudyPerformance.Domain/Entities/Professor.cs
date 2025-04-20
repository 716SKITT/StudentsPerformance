public class Professor
{
    public Guid Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string? Email { get; private set; }

    public string? PhoneNumber { get; private set; }

    public string? Department { get; private set; }

    private Professor() { }

    public Professor(string firstName, string lastName, string? email = null, string? phoneNumber = null, string? department = null)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Department = department;
    }

    public void UpdateContact(string? email, string? phoneNumber)
    {
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public void UpdateDepartment(string? department)
    {
        Department = department;
    }
}
