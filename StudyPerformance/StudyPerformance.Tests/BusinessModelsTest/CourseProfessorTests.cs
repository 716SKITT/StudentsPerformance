using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class CourseProfessorTests
{
    [Fact]
    public void Can_Create_CourseProfessor()
    {
        var courseId = Guid.NewGuid();
        var professorId = Guid.NewGuid();

        var courseProfessor = new CourseProfessor(courseId, professorId);

        Assert.Equal(courseId, courseProfessor.CourseId);
        Assert.Equal(professorId, courseProfessor.ProfessorId);
        Assert.True(courseProfessor.Id != Guid.Empty);
    }
}
