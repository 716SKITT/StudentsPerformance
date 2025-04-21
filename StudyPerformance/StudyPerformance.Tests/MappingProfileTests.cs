using AutoMapper;
using StudyPerformance.Infrastructure.Mapping;
using Xunit;
using StudyPerformance.Infrastructure.EF.Models;
using StudyPerformance.Domain.Entities;
using System;

namespace StudyPerformance.Tests
{
    public class MappingProfileTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingProfileTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainMappingProfile>();
            });
            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void Mapping_Configuration_IsValid()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void Can_Map_Professor()
        {
            var source = new professor
            {
                professorid = 1,
                firstname = "John",
                lastname = "Doe",
                email = "john.doe@example.com",
                phonenumber = "123456789",
                department = "Math"
            };

            var result = _mapper.Map<Professor>(source);

            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
            Assert.Equal("john.doe@example.com", result.Email);
        }

        [Fact]
        public void Can_Map_Exam()
        {
            var source = new exam
            {
                courseid = 1,
                examname = "Midterm",
                examdate = DateOnly.FromDateTime(DateTime.Today),
                maxscore = 100
            };

            var result = _mapper.Map<Exam>(source);

            Assert.Equal("Midterm", result.Name);
            Assert.Equal(100, result.MaxScore);
        }

        [Fact]
        public void Can_Map_Grade()
        {
            var source = new grade
            {
                enrollmentid = 1,
                assignmentid = 2,
                pointsearned = 95
            };

            var result = _mapper.Map<Grade>(source);

            Assert.Equal(95, result.PointsEarned);
        }

        [Fact]
        public void Can_Map_Assignment()
        {
            var source = new assignment
            {
                courseid = 5,
                assignmentname = "Essay",
                duedate = DateOnly.FromDateTime(DateTime.Today),
                maxpoints = 50,
                description = "Write an essay"
            };

            var result = _mapper.Map<Assignment>(source);

            Assert.Equal("Essay", result.Name);
            Assert.Equal(50, result.MaxPoints);
        }

        [Fact]
        public void Can_Map_Enrollment()
        {
            var source = new enrollment
            {
                studentid = 1,
                courseid = 2,
                enrollmentdate = DateOnly.FromDateTime(DateTime.Today)
            };

            var result = _mapper.Map<Enrollment>(source);

            Assert.Equal(DateOnly.FromDateTime(DateTime.Today), result.EnrollmentDate);
        }

        [Fact]
        public void Can_Map_ExamResult()
        {
            var source = new examresult
            {
                enrollmentid = 1,
                examid = 2,
                score = 88
            };

            var result = _mapper.Map<ExamResult>(source);

            Assert.Equal(88, result.Score);
        }

        [Fact]
        public void Can_Map_Attendance()
        {
            var source = new attendance
            {
                enrollmentid = 1,
                attendancedate = DateOnly.FromDateTime(DateTime.Today),
                status = 'P'
            };

            var result = _mapper.Map<Attendance>(source);

            Assert.Equal(AttendanceStatus.Present, result.Status);
        }

        [Fact]
        public void Can_Map_AuditLog()
        {
            var source = new auditlog
            {
                tablename = "Student",
                operationtype = "INSERT",
                operationtime = DateTime.UtcNow,
                username = "admin"
            };

            var result = _mapper.Map<AuditLog>(source);

            Assert.Equal("Student", result.TableName);
            Assert.Equal("INSERT", result.OperationType);
        }

        [Fact]
        public void Can_Map_Course()
        {
            var source = new course
            {
                coursename = "History",
                credits = 3,
                coursedescription = "World history"
            };

            var result = _mapper.Map<Course>(source);

            Assert.Equal("History", result.Name);
            Assert.Equal(3, result.Credits);
        }

        [Fact]
        public void Can_Map_CourseProfessor()
        {
            var source = new courseprofessor
            {
                courseid = 1,
                professorid = 2
            };

            var result = _mapper.Map<CourseProfessor>(source);

            Assert.NotEqual(Guid.Empty, result.CourseId);
            Assert.NotEqual(Guid.Empty, result.ProfessorId);
        }
    }
}
