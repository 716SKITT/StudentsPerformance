using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class ExamTests
{
    [Fact]
    public void Can_Create_Exam()
    {
        var courseId = Guid.NewGuid();
        var exam = new Exam(courseId, "Контрольная точка", DateOnly.FromDateTime(DateTime.Today.AddDays(10)), 100);

        Assert.Equal(courseId, exam.CourseId);
        Assert.Equal("Контрольная точка", exam.Name);
        Assert.Equal(100, exam.MaxScore);
        Assert.True(exam.Id != Guid.Empty);
    }

    [Fact]
    public void Throws_On_Empty_Exam_Name()
    {
        var courseId = Guid.NewGuid();

        Assert.Throws<ArgumentException>(() =>
            new Exam(courseId, "", DateOnly.FromDateTime(DateTime.Today.AddDays(1)), 50));
    }

    [Fact]
    public void Throws_On_Negative_MaxScore()
    {
        var courseId = Guid.NewGuid();

        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Exam(courseId, "Тест", DateOnly.FromDateTime(DateTime.Today.AddDays(1)), 0));
    }

    [Fact]
    public void Can_Reschedule_Exam()
    {
        var exam = new Exam(Guid.NewGuid(), "Экзамен", DateOnly.FromDateTime(DateTime.Today.AddDays(10)), 100);
        var newDate = DateOnly.FromDateTime(DateTime.Today.AddDays(20));

        exam.Reschedule(newDate);

        Assert.Equal(newDate, exam.ExamDate);
    }

    [Fact]
    public void Throws_When_Reschedule_To_Past()
    {
        var exam = new Exam(Guid.NewGuid(), "Экзамен", DateOnly.FromDateTime(DateTime.Today.AddDays(5)), 100);

        var pastDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        Assert.Throws<ArgumentException>(() => exam.Reschedule(pastDate));
    }

    [Fact]
    public void Can_Update_MaxScore()
    {
        var exam = new Exam(Guid.NewGuid(), "Контрольная", DateOnly.FromDateTime(DateTime.Today.AddDays(3)), 50);

        exam.UpdateMaxScore(75);

        Assert.Equal(75, exam.MaxScore);
    }

    [Fact]
    public void Throws_When_New_MaxScore_Is_Invalid()
    {
        var exam = new Exam(Guid.NewGuid(), "Контрольная", DateOnly.FromDateTime(DateTime.Today.AddDays(3)), 50);

        Assert.Throws<ArgumentOutOfRangeException>(() => exam.UpdateMaxScore(0));
    }
}
