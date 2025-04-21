using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class CourseTests
{
    [Fact]
    public void Can_Create_Course()
    {
        var course = new Course("Информационная безопасность", 5, "основы");

        Assert.Equal("Информационная безопасность", course.Name);
        Assert.Equal(5, course.Credits);
        Assert.Equal("основы", course.Description);
        Assert.True(course.Id != Guid.Empty);
    }

    [Fact]
    public void Test_Null_Course_Name()
    {
        Assert.Throws<ArgumentException>(() => new Course(null, 5, "ОСНОВЫ"));
    }
    
    [Fact]
    public void Test_Negative_Credits()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Course("Информационная безопасность", -1, "основы"));
    }

    [Fact]
    public void Test_Update_Description()
    {
        var course = new Course("Информационная безопасность", 5, "основы");
        var newDescription = "новое описание";

        course.UpdateDescription(newDescription);

        Assert.Equal(newDescription, course.Description);
    }

    [Fact]
    public void Test_Update_Credits()
    {
        var course = new Course("Информационная безопасность", 5, "основы");
        var newCredits = 10;

        course.UpdateCredits(newCredits);

        Assert.Equal(newCredits, course.Credits);
    }
}



//  public void UpdateDescription(string? description)
//     {
//         Description = description;
//     }

//     public void UpdateCredits(int credits)
//     {
//         if (credits <= 0)
//             throw new ArgumentOutOfRangeException(nameof(credits), "Credits must be greater than zero.");

//         Credits = credits;
//     }