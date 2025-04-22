using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StudyPerformance.Infrastructure.EF;

namespace StudyPerformance.Infrastructure;

public class StudentDbContextFactory : IDesignTimeDbContextFactory<StudentDbContext>
{
    public StudentDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();

        optionsBuilder.UseNpgsql("Host=localhost;Port=5430;Database=student_db;Username=student_admin;Password=69*@dminPG");

        return new StudentDbContext(optionsBuilder.Options);
    }
}
