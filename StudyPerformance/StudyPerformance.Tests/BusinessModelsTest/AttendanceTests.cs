using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class AttendanceTests
{
    [Fact]
    public void Can_Create_Attendance_Present()
    {
        var enrollmentId = Guid.NewGuid();
        var date = DateOnly.FromDateTime(DateTime.Today);

        var attendance = new Attendance(enrollmentId, date, AttendanceStatus.Present);

        Assert.Equal(enrollmentId, attendance.EnrollmentId);
        Assert.Equal(date, attendance.AttendanceDate);
        Assert.Equal(AttendanceStatus.Present, attendance.Status);
        Assert.True(attendance.Id != Guid.Empty);
    }

    [Fact]
    public void Can_Create_Attendance_Absent()
    {
        var enrollmentId = Guid.NewGuid();
        var date = DateOnly.FromDateTime(DateTime.Today);

        var attendance = new Attendance(enrollmentId, date, AttendanceStatus.Absent);

        Assert.Equal(AttendanceStatus.Absent, attendance.Status);
    }
}
