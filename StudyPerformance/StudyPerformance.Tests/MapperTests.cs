using AutoMapper;
using StudyPerformance.Domain.Entities;
using StudyPerformance.Infrastructure.EF.Models;
using StudyPerformance.Infrastructure.Mapping;
using Xunit;

namespace StudyPerformance.Tests;

public class MapperTests
{
    private readonly IMapper _mapper;

    public MapperTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DomainMappingProfile>();
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Can_Map_EF_Student_To_Domain_Student()
    {
        var efStudent = new student
        {
            firstname = "Тест",
            lastname = "Студент",
            dateofbirth = new DateOnly(2000, 1, 1),
            gender = 'M',
            email = "test@example.com",
            phonenumber = "+70000000000",
            address = "123 Main St",
            enrollmentdate = new DateOnly(2023, 9, 1)
        };

        var domainStudent = _mapper.Map<Student>(efStudent);

        Assert.Equal("Тест", domainStudent.FirstName);
        Assert.Equal("Студент", domainStudent.LastName);
        Assert.Equal("test@example.com", domainStudent.Email);
    }
}
