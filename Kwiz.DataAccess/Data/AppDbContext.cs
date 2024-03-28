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
        builder.Entity<Quiz>(entity =>
        {
            entity.HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId);

            entity.HasMany(q => q.Submissions)
                .WithOne(s => s.Quiz)
                .HasForeignKey(s => s.QuizId);
        });

        builder.Entity<Owner>(entity =>
        {
            entity.HasMany(o => o.Quizzes)
                .WithOne(q => q.Owner)
                .HasForeignKey(q => q.OwnerId);
        });

        builder.Entity<Question>(entity =>
        {
            entity.HasMany(q => q.Options)
                .WithOne()
                .HasForeignKey(q => q.QuestionId);
        });

        builder.Entity<Interest>(entity =>
        {
            entity.HasMany(i => i.InterestedTechnologies)
                .WithOne(t => t.Interest)
                .HasForeignKey(i => i.InterestId);
        });

        builder.Entity<Technology>(entity =>
        {
            entity.HasOne(t => t.Interest)
                .WithMany(i => i.InterestedTechnologies)
                .HasForeignKey(i => i.InterestId);
        });

        builder.Entity<Submission>(entity =>
        {
            entity.HasOne(s => s.Quiz)
                .WithMany(q => q.Submissions)
                .HasForeignKey(q => q.QuizId);
        });

        base.OnModelCreating(builder);
    }
}
