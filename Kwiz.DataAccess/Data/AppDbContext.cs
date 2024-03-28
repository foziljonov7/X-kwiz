using Kwiz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.DataAccess.Data;

public class AppDbContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Submission> Submissions { get; set; }
    public DbSet<QuestionOptions> Options { get; set; }
    public DbSet<SubmissionSelection> Selections { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
