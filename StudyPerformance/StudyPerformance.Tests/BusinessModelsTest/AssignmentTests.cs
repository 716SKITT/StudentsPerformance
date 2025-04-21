using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class AssignmentTests
{
    [Fact]
    public void Can_Create_Assignment()
    {
        var courseId = Guid.NewGuid();
        var assignment = new Assignment(courseId, "лаба 4", DateOnly.FromDateTime(DateTime.Today.AddDays(5)), 20, "https://metanit.com/sharp/");

        Assert.Equal(courseId, assignment.CourseId);
        Assert.Equal("лаба 4", assignment.Name);
        Assert.Equal(20, assignment.MaxPoints);
        Assert.Equal("https://metanit.com/sharp/", assignment.Description);
        Assert.True(assignment.Id != Guid.Empty);
    }

    [Fact]
    public void Throws_On_Empty_Name()
    {
        var courseId = Guid.NewGuid();

        Assert.Throws<ArgumentException>(() =>
            new Assignment(courseId, "", DateOnly.FromDateTime(DateTime.Today.AddDays(5)), 10));
    }

    [Fact]
    public void Throws_On_Zero_MaxPoints()
    {
        var courseId = Guid.NewGuid();

        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Assignment(courseId, "Лаба", DateOnly.FromDateTime(DateTime.Today.AddDays(5)), 0));
    }

    [Fact]
    public void Can_Update_Assignment_Details()
    {
        var courseId = Guid.NewGuid();
        var assignment = new Assignment(courseId, "Старая лаба", DateOnly.FromDateTime(DateTime.Today.AddDays(5)), 10, "старое описание");

        var newName = "Обновлённая лаба";
        var newDate = DateOnly.FromDateTime(DateTime.Today.AddDays(10));
        var newPoints = 30;
        var newDescription = "новое описание";

        assignment.UpdateDetails(newName, newDate, newPoints, newDescription);

        Assert.Equal(newName, assignment.Name);
        Assert.Equal(newDate, assignment.DueDate);
        Assert.Equal(newPoints, assignment.MaxPoints);
        Assert.Equal(newDescription, assignment.Description);
    }

    [Fact]
    public void Update_Assignment_Details_Allows_Null_Description()
    {
        var courseId = Guid.NewGuid();
        var assignment = new Assignment(courseId, "Задание", DateOnly.FromDateTime(DateTime.Today.AddDays(3)), 15, "описание");

        assignment.UpdateDetails("Новое задание", DateOnly.FromDateTime(DateTime.Today.AddDays(10)), 25);

        Assert.Equal("Новое задание", assignment.Name);
        Assert.Equal(25, assignment.MaxPoints);
        Assert.Null(assignment.Description);
    }
}
