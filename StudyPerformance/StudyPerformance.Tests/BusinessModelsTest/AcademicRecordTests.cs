using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class AcademicRecordTests
{
    [Fact]
    public void Can_Create_AcademicRecord()
    {
        var studentId = Guid.NewGuid();
        decimal gpa = 4.5m;
        int year = 2024;
        int semester = 1;

        var record = new AcademicRecord(studentId, gpa, year, semester);

        Assert.Equal(studentId, record.StudentId);
        Assert.Equal(4.5m, record.GPA);
        Assert.Equal(2024, record.AcademicYear);
        Assert.Equal(1, record.Semester);
        Assert.True(record.Id != Guid.Empty);
    }

    [Fact]
    public void Can_Update_Gpa()
    {
        var record = new AcademicRecord(Guid.NewGuid(), 3.2m, 2023, 2);

        record.UpdateGpa(4.8m);

        Assert.Equal(4.8m, record.GPA);
    }

    [Fact]
    public void UpdateGpa_Throws_If_Invalid()
    {
        var record = new AcademicRecord(Guid.NewGuid(), 3.5m, 2023, 2);

        Assert.Throws<ArgumentOutOfRangeException>(() => record.UpdateGpa(6.0m));
        Assert.Throws<ArgumentOutOfRangeException>(() => record.UpdateGpa(-1m));
    }
}
