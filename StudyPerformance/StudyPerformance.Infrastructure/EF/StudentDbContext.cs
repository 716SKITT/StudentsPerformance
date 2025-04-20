using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using StudyPerformance.Infrastructure.EF.Models;

namespace StudyPerformance.Domain.Data;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<academicrecord> academicrecords { get; set; }

    public virtual DbSet<assignment> assignments { get; set; }

    public virtual DbSet<attendance> attendances { get; set; }

    public virtual DbSet<auditlog> auditlogs { get; set; }

    public virtual DbSet<course> courses { get; set; }

    public virtual DbSet<courseprofessor> courseprofessors { get; set; }

    public virtual DbSet<enrollment> enrollments { get; set; }

    public virtual DbSet<exam> exams { get; set; }

    public virtual DbSet<examresult> examresults { get; set; }

    public virtual DbSet<grade> grades { get; set; }

    public virtual DbSet<professor> professors { get; set; }

    public virtual DbSet<student> students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5430;Database=student_db;Username=student_admin;Password=69*@dminPG");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<academicrecord>(entity =>
        {
            entity.HasKey(e => e.recordid).HasName("academicrecords_pkey");

            entity.Property(e => e.gpa).HasPrecision(3, 2);

            entity.HasOne(d => d.student).WithMany(p => p.academicrecords)
                .HasForeignKey(d => d.studentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("academicrecords_studentid_fkey");
        });

        modelBuilder.Entity<assignment>(entity =>
        {
            entity.HasKey(e => e.assignmentid).HasName("assignments_pkey");

            entity.Property(e => e.assignmentname).HasMaxLength(100);

            entity.HasOne(d => d.course).WithMany(p => p.assignments)
                .HasForeignKey(d => d.courseid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("assignments_courseid_fkey");
        });

        modelBuilder.Entity<attendance>(entity =>
        {
            entity.HasKey(e => e.attendanceid).HasName("attendance_pkey");

            entity.ToTable("attendance");

            entity.Property(e => e.status).HasMaxLength(1);

            entity.HasOne(d => d.enrollment).WithMany(p => p.attendances)
                .HasForeignKey(d => d.enrollmentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("attendance_enrollmentid_fkey");
        });

        modelBuilder.Entity<auditlog>(entity =>
        {
            entity.HasKey(e => e.auditid).HasName("auditlog_pkey");

            entity.ToTable("auditlog");

            entity.Property(e => e.operationtime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.operationtype).HasMaxLength(10);
            entity.Property(e => e.tablename).HasMaxLength(100);
            entity.Property(e => e.username).HasMaxLength(100);
        });

        modelBuilder.Entity<course>(entity =>
        {
            entity.HasKey(e => e.courseid).HasName("courses_pkey");

            entity.Property(e => e.coursename).HasMaxLength(100);
        });

        modelBuilder.Entity<courseprofessor>(entity =>
        {
            entity.HasKey(e => e.courseprofessorid).HasName("courseprofessors_pkey");

            entity.HasOne(d => d.course).WithMany(p => p.courseprofessors)
                .HasForeignKey(d => d.courseid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("courseprofessors_courseid_fkey");

            entity.HasOne(d => d.professor).WithMany(p => p.courseprofessors)
                .HasForeignKey(d => d.professorid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("courseprofessors_professorid_fkey");
        });

        modelBuilder.Entity<enrollment>(entity =>
        {
            entity.HasKey(e => e.enrollmentid).HasName("enrollments_pkey");

            entity.HasOne(d => d.course).WithMany(p => p.enrollments)
                .HasForeignKey(d => d.courseid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("enrollments_courseid_fkey");

            entity.HasOne(d => d.student).WithMany(p => p.enrollments)
                .HasForeignKey(d => d.studentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("enrollments_studentid_fkey");
        });

        modelBuilder.Entity<exam>(entity =>
        {
            entity.HasKey(e => e.examid).HasName("exams_pkey");

            entity.Property(e => e.examname).HasMaxLength(100);

            entity.HasOne(d => d.course).WithMany(p => p.exams)
                .HasForeignKey(d => d.courseid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("exams_courseid_fkey");
        });

        modelBuilder.Entity<examresult>(entity =>
        {
            entity.HasKey(e => e.examresultid).HasName("examresults_pkey");

            entity.HasOne(d => d.enrollment).WithMany(p => p.examresults)
                .HasForeignKey(d => d.enrollmentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("examresults_enrollmentid_fkey");

            entity.HasOne(d => d.exam).WithMany(p => p.examresults)
                .HasForeignKey(d => d.examid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("examresults_examid_fkey");
        });

        modelBuilder.Entity<grade>(entity =>
        {
            entity.HasKey(e => e.gradeid).HasName("grades_pkey");

            entity.HasOne(d => d.assignment).WithMany(p => p.grades)
                .HasForeignKey(d => d.assignmentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("grades_assignmentid_fkey");

            entity.HasOne(d => d.enrollment).WithMany(p => p.grades)
                .HasForeignKey(d => d.enrollmentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("grades_enrollmentid_fkey");
        });

        modelBuilder.Entity<professor>(entity =>
        {
            entity.HasKey(e => e.professorid).HasName("professors_pkey");

            entity.HasIndex(e => e.email, "professors_email_key").IsUnique();

            entity.Property(e => e.department).HasMaxLength(100);
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.firstname).HasMaxLength(50);
            entity.Property(e => e.lastname).HasMaxLength(50);
            entity.Property(e => e.phonenumber).HasMaxLength(20);
        });

        modelBuilder.Entity<student>(entity =>
        {
            entity.HasKey(e => e.studentid).HasName("students_pkey");

            entity.HasIndex(e => e.email, "students_email_key").IsUnique();

            entity.Property(e => e.address).HasMaxLength(255);
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.firstname).HasMaxLength(50);
            entity.Property(e => e.gender).HasMaxLength(1);
            entity.Property(e => e.lastname).HasMaxLength(50);
            entity.Property(e => e.phonenumber).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
