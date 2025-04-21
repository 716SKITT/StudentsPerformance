using AutoMapper;
using StudyPerformance.Domain.Entities;
using StudyPerformance.Infrastructure.EF.Models;
using StudyPerformance.Infrastructure.Utils;

namespace StudyPerformance.Infrastructure.Mapping;

public class DomainMappingProfile : Profile
{
    public DomainMappingProfile()
    {
        CreateMap<student, Student>()
            .ConstructUsing(src =>
                new Student(
                    GuidIdMapper.FromInt(src.studentid),
                    src.firstname,
                    src.lastname,
                    src.enrollmentdate,
                    src.dateofbirth,
                    src.gender != null ? src.gender.ToString() : null
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.phonenumber))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.address))
            .ForMember(dest => dest.Enrollments, opt => opt.Ignore());

        CreateMap<professor, Professor>()
            .ConstructUsing(src => new Professor(src.firstname, src.lastname, src.email, src.phonenumber, src.department))
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<academicrecord, AcademicRecord>()
            .ConstructUsing(src =>
                new AcademicRecord(
                    GuidIdMapper.FromInt(src.studentid),
                    src.gpa,
                    src.academicyear,
                    src.semester
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.StudentId, opt => opt.Ignore());

        CreateMap<assignment, Assignment>()
            .ConstructUsing(src =>
                new Assignment(
                    GuidIdMapper.FromInt(src.courseid),
                    src.assignmentname,
                    src.duedate,
                    src.maxpoints,
                    src.description
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CourseId, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.Ignore());

        CreateMap<attendance, Attendance>()
            .ConstructUsing(src =>
                new Attendance(
                    GuidIdMapper.FromInt(src.enrollmentid),
                    src.attendancedate,
                    src.status == 'P' ? AttendanceStatus.Present : AttendanceStatus.Absent
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.EnrollmentId, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore());

        CreateMap<auditlog, AuditLog>()
            .ConstructUsing(src =>
                new AuditLog(
                    src.tablename ?? string.Empty,
                    src.operationtype ?? string.Empty,
                    src.operationtime ?? DateTime.UtcNow,
                    src.username ?? "System"
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<course, Course>()
            .ConstructUsing(src =>
                new Course(
                    src.coursename,
                    src.credits,
                    src.coursedescription
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.Ignore())
            .ForMember(dest => dest.Description, opt => opt.Ignore());

        CreateMap<courseprofessor, CourseProfessor>()
            .ConstructUsing(src =>
                new CourseProfessor(
                    GuidIdMapper.FromInt(src.courseid),
                    GuidIdMapper.FromInt(src.professorid)
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CourseId, opt => opt.Ignore())
            .ForMember(dest => dest.ProfessorId, opt => opt.Ignore());

        CreateMap<enrollment, Enrollment>()
            .ConstructUsing(src =>
                new Enrollment(
                    GuidIdMapper.FromInt(src.studentid),
                    GuidIdMapper.FromInt(src.courseid),
                    src.enrollmentdate
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.StudentId, opt => opt.Ignore())
            .ForMember(dest => dest.CourseId, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore());

        CreateMap<exam, Exam>()
            .ConstructUsing(src =>
                new Exam(
                    GuidIdMapper.FromInt(src.courseid),
                    src.examname,
                    src.examdate,
                    src.maxscore
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CourseId, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.Ignore());

        CreateMap<examresult, ExamResult>()
            .ConstructUsing(src =>
                new ExamResult(
                    GuidIdMapper.FromInt(src.enrollmentid),
                    GuidIdMapper.FromInt(src.examid),
                    src.score
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.EnrollmentId, opt => opt.Ignore())
            .ForMember(dest => dest.ExamId, opt => opt.Ignore());

        CreateMap<grade, Grade>()
            .ConstructUsing(src =>
                new Grade(
                    GuidIdMapper.FromInt(src.enrollmentid),
                    GuidIdMapper.FromInt(src.assignmentid),
                    src.pointsearned
                ))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.EnrollmentId, opt => opt.Ignore())
            .ForMember(dest => dest.AssignmentId, opt => opt.Ignore());
    }
}
