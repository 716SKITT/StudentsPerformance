using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class EnrollmentTests
{
    [Fact]
    public void Can_Create_Enrollment()
    {
        var studentId = Guid.NewGuid();
        var courseId = Guid.NewGuid();
        var date = DateOnly.FromDateTime(DateTime.Today);

        var enrollment = new Enrollment(studentId, courseId, date);

        Assert.Equal(studentId, enrollment.StudentId);
        Assert.Equal(courseId, enrollment.CourseId);
        Assert.Equal(date, enrollment.EnrollmentDate);
        Assert.True(enrollment.Id != Guid.Empty);
    }

    [Fact]
    public void Can_Mark_As_Completed()
    {
        var studentId = Guid.NewGuid();
        var courseId = Guid.NewGuid();
        var date = DateOnly.FromDateTime(DateTime.Today);

        var enrollment = new Enrollment(studentId, courseId, date);
    
        enrollment.MarkAsCompleted();

        Assert.Equal(EnrollmentStatus.Completed, enrollment.Status);
    }

    [Fact]
    public void Can_Mark_As_Withdrawn()
    {
        var studentId = Guid.NewGuid();
        var courseId = Guid.NewGuid();
        var date = DateOnly.FromDateTime(DateTime.Today);

        var enrollment = new Enrollment(studentId, courseId, date);
    
        enrollment.MarkAsWithdrawn();

        Assert.Equal(EnrollmentStatus.Withdrawn, enrollment.Status);
    }
}





// public void MarkAsWithdrawn()
//     {
//         if (Status == EnrollmentStatus.Withdrawn)
//             throw new InvalidOperationException("Enrollment already withdrawn.");

//         Status = EnrollmentStatus.Withdrawn;
//     }

//     public void MarkAsCompleted()
//     {
//         if (Status != EnrollmentStatus.Active)
//             throw new InvalidOperationException("Only active enrollments can be completed.");

//         Status = EnrollmentStatus.Completed;
//     }
// }
