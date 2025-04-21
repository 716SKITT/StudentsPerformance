using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class StudentTests
{
    [Fact]
    public void Can_Create_Student()
    {
        var student = new Student("Иван", "Иванов", DateOnly.FromDateTime(DateTime.Today));

        Assert.Equal("Иван", student.FirstName);
        Assert.Equal("Иванов", student.LastName);
        Assert.True(student.Id != Guid.Empty);
    }

    [Fact]
    public void Can_Add_Enrollment_To_Student()
    {
        var student = new Student("Мария", "Петрова", DateOnly.FromDateTime(DateTime.Today));
        var enrollment = new Enrollment(student.Id, Guid.NewGuid(), DateOnly.FromDateTime(DateTime.Today));

        student.AddEnrollment(enrollment);

        Assert.Single(student.Enrollments);
    }

    [Fact]
    public void Can_Update_Contact()
    {
        var student = new Student("Елена", "Сидорова", DateOnly.FromDateTime(DateTime.Today));
        student.UpdateContact("elena@example.com", "+123456789");

        Assert.Equal("elena@example.com", student.Email);
        Assert.Equal("+123456789", student.PhoneNumber);
    }
}
