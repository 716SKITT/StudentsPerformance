using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class ExamResultTests
{
    [Fact]
    public void Can_Create_Exam_Result()
    {
        var enrollmentId = Guid.NewGuid();
        var examId = Guid.NewGuid();
        var result = new ExamResult(enrollmentId, examId, 88);

        Assert.Equal(enrollmentId, result.EnrollmentId);
        Assert.Equal(examId, result.ExamId);
        Assert.Equal(88, result.Score);
        Assert.True(result.Id != Guid.Empty);
    }
}
