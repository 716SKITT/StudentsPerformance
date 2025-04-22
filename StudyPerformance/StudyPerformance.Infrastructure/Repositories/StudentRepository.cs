using Microsoft.EntityFrameworkCore;
using StudyPerformance.Application.Repositories;
using StudyPerformance.Domain.Entities;
using StudyPerformance.Infrastructure.EF;

namespace StudyPerformance.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext _context;

    public StudentRepository(StudentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync() =>
        await _context.Students.ToListAsync();

    public async Task<Student?> GetByIdAsync(Guid id) =>
        await _context.Students.FindAsync(id);

    public async Task AddAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student is null) return;
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }
}
