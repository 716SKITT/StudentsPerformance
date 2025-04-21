using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class GradeTests
{
    [Fact]
    public void Can_Create_Grade()
    {
        var enrollmentId = Guid.NewGuid();
        var assignmentId = Guid.NewGuid();
        var grade = new Grade(enrollmentId, assignmentId, 5);

        Assert.Equal(enrollmentId, grade.EnrollmentId);
        Assert.Equal(assignmentId, grade.AssignmentId);
        Assert.Equal(5, grade.PointsEarned);
        Assert.True(grade.Id != Guid.Empty);
    }
}
