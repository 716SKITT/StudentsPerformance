using System;
using StudyPerformance.Domain.Entities;
using Xunit;

namespace StudyPerformance.Tests;

public class ProfessorTests
{
    [Fact]
    public void Can_Create_Professor()
    {
        var professor = new Professor("Виталий", "Сидоров", "VSidorov@tisbi.ru", "+71234567890", "Разработка и тестирование ПО");

        Assert.Equal("Виталий", professor.FirstName);
        Assert.Equal("Сидоров", professor.LastName);
        Assert.Equal("VSidorov@tisbi.ru", professor.Email);
        Assert.Equal("+71234567890", professor.PhoneNumber);
        Assert.Equal("Разработка и тестирование ПО", professor.Department);
        Assert.True(professor.Id != Guid.Empty);
    }
}
