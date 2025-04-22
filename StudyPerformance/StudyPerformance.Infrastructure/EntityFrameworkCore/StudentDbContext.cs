using Microsoft.EntityFrameworkCore;
using StudyPerformance.Domain.Entities;

namespace StudyPerformance.Infrastructure.EF;

public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<Exam> Exams => Set<Exam>();
    public DbSet<ExamResult> ExamResults => Set<ExamResult>();
    public DbSet<CourseProfessor> CourseProfessors => Set<CourseProfessor>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<AcademicRecord> AcademicRecords => Set<AcademicRecord>();
    public DbSet<Professor> Professors => Set<Professor>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Student
        modelBuilder.Entity<Student>()
            .HasIndex(s => s.Email)
            .IsUnique();

        modelBuilder.Entity<Student>()
            .Property(s => s.FirstName).HasMaxLength(50);
        modelBuilder.Entity<Student>()
            .Property(s => s.LastName).HasMaxLength(50);
        modelBuilder.Entity<Student>()
            .Property(s => s.Gender).HasMaxLength(1);
        modelBuilder.Entity<Student>()
            .Property(s => s.Email).HasMaxLength(100);
        modelBuilder.Entity<Student>()
            .Property(s => s.PhoneNumber).HasMaxLength(20);
        modelBuilder.Entity<Student>()
            .Property(s => s.Address).HasMaxLength(255);

        // Course
        modelBuilder.Entity<Course>()
            .Property(c => c.Name).HasMaxLength(100);

        // Enrollment
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Assignment
        modelBuilder.Entity<Assignment>()
            .Property(a => a.Name)
            .HasMaxLength(100);
        modelBuilder.Entity<Assignment>()
            .HasOne(a => a.Course)
            .WithMany(c => c.Assignments)
            .HasForeignKey(a => a.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Grade
        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Enrollment)
            .WithMany(e => e.Grades)
            .HasForeignKey(g => g.EnrollmentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Assignment)
            .WithMany(a => a.Grades)
            .HasForeignKey(g => g.AssignmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Exam
        modelBuilder.Entity<Exam>()
            .Property(e => e.Name)
            .HasMaxLength(100);

        modelBuilder.Entity<Exam>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Exams)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // ExamResult
        modelBuilder.Entity<ExamResult>()
            .HasOne(er => er.Exam)
            .WithMany(e => e.ExamResults)
            .HasForeignKey(er => er.ExamId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ExamResult>()
            .HasOne(er => er.Enrollment)
            .WithMany(e => e.ExamResults)
            .HasForeignKey(er => er.EnrollmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // CourseProfessor
        modelBuilder.Entity<CourseProfessor>()
            .HasOne(cp => cp.Course)
            .WithMany(c => c.CourseProfessors)
            .HasForeignKey(cp => cp.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CourseProfessor>()
            .HasOne(cp => cp.Professor)
            .WithMany(p => p.CourseProfessors)
            .HasForeignKey(cp => cp.ProfessorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Attendance
        modelBuilder.Entity<Attendance>()
            .Property(a => a.Status)
            .HasColumnType("char(1)");

        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Enrollment)
            .WithMany(e => e.Attendances)
            .HasForeignKey(a => a.EnrollmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // AcademicRecord
        modelBuilder.Entity<AcademicRecord>()
            .Property(a => a.GPA).HasPrecision(3, 2);

        modelBuilder.Entity<AcademicRecord>()
            .HasOne(ar => ar.Student)
            .WithMany(s => s.AcademicRecords)
            .HasForeignKey(ar => ar.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Professor
        modelBuilder.Entity<Professor>()
            .HasIndex(p => p.Email)
            .IsUnique();

        modelBuilder.Entity<Professor>()
            .Property(p => p.FirstName).HasMaxLength(50);
        modelBuilder.Entity<Professor>()
            .Property(p => p.LastName).HasMaxLength(50);
        modelBuilder.Entity<Professor>()
            .Property(p => p.Email).HasMaxLength(100);
        modelBuilder.Entity<Professor>()
            .Property(p => p.PhoneNumber).HasMaxLength(20);
        modelBuilder.Entity<Professor>()
            .Property(p => p.Department).HasMaxLength(100);

        // AuditLog
        modelBuilder.Entity<AuditLog>()
            .Property(a => a.TableName).HasMaxLength(100);
        modelBuilder.Entity<AuditLog>()
            .Property(a => a.OperationType).HasMaxLength(10);
        modelBuilder.Entity<AuditLog>()
            .Property(a => a.Username).HasMaxLength(100);
    }

}
