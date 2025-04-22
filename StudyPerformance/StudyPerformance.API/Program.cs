using Microsoft.EntityFrameworkCore;
using StudyPerformance.Infrastructure.EF;
using StudyPerformance.Domain.Entities;
using StudyPerformance.Application.Repositories;
using StudyPerformance.Infrastructure.Repositories;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<StudentDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<StudentDbContext>();
            var student = new Student("кто-то", "фыв", new DateOnly(2000, 5, 20));
            db.Students.Add(student);
            await db.SaveChangesAsync();

            Console.WriteLine($"Student created: {student.Id} - {student.FirstName} {student.LastName}");
        }

        await app.RunAsync();
    }

    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
