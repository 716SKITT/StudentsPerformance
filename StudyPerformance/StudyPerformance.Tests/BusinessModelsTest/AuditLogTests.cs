using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class AuditLogTests
{
    [Fact]
    public void Can_Create_AuditLog()
    {
        var log = new AuditLog("students", "INSERT", DateTime.UtcNow, "admin");

        Assert.Equal("students", log.TableName);
        Assert.Equal("INSERT", log.OperationType);
        Assert.Equal("admin", log.Username);
        Assert.True(log.Id != Guid.Empty);
    }
}
