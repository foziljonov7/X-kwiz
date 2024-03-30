using Kwiz.DataAccess.Data;
using Kwiz.DataAccess.DTOs;
using Kwiz.Domain.Entities;
using Kwiz.Domain.Enums;
using Kwiz.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.Infrastructure.Repositories;
public class QuizRepository : IQuizRepository
{
    private readonly AppDbContext dbContext;

    public QuizRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<GeneralResponse> CreateQuizAsync(QuizDTO newQuiz)
    {
        var quiz = new Quiz
        {
            Id = Guid.NewGuid(),
            OwnerId = newQuiz.OwnerId,
            Title = newQuiz.Title,
            Description = newQuiz.Description,
            CreatedAt = DateTime.UtcNow.AddHours(5),
            OpeningDate = newQuiz.OpeningDate,
            ClosingDate = newQuiz.ClosingDate,
            IsPublic = newQuiz.IsPublic,
            Tags = newQuiz.Tags,
            Code = newQuiz.Code,
            Status = Status.Disable
        };

        await dbContext.Quizzes.AddAsync(quiz);
        await dbContext.SaveChangesAsync();

        return new GeneralResponse(true, "Successfully saved");
    }

    public async Task<Quiz> GetQuizAsync(Guid id)
    {
        var quiz = await dbContext.Quizzes
            .Include(q => q.Owner)
            .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
            .Include(q => q.Submissions)
            .FirstOrDefaultAsync(q => q.Id == id);

        if (quiz is null || quiz.Status is Status.Deleted)
            throw new NotSupportedException("Reference is null or there is some kind of interruption");

        return quiz;
    }

    public async Task<IEnumerable<Quiz>> GetQuizzesAsync()
        => await dbContext.Quizzes
            .Include(q => q.Owner)
            .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
            .Include(q => q.Submissions)
            .Where(q => q.Status == Status.Active)
            .ToListAsync();

    public async Task<GeneralResponse> RemoveQuizAsync(Guid id)
    {
        var quiz = await dbContext.Quizzes
            .FirstOrDefaultAsync(q => q.Id == id);

        if (quiz is null || quiz.Status is Status.Disable)
            return new GeneralResponse(false, "Quiz not found");

        quiz.Status = Status.Deleted;
        await dbContext.SaveChangesAsync();
        return new GeneralResponse(true, "Successfully deleted");
    }

    public async Task<GeneralResponse> UpdateQuizAsync(Guid id, QuizDTO quiz)
    {
        var updated = await dbContext.Quizzes
            .FirstOrDefaultAsync(q => q.Id == id);

        if (updated is null || updated.Status is Status.Disable)
            return new GeneralResponse(false, "Quiz not found");

        updated.Title = quiz.Title;
        updated.Description = quiz.Description;
        updated.IsPublic = quiz.IsPublic;
        updated.UpdatedAt = DateTime.UtcNow.AddHours(5);
        updated.OpeningDate = quiz.OpeningDate;
        updated.ClosingDate = quiz.ClosingDate;
        updated.Tags = quiz.Tags;
        updated.Code = quiz.Code;

        await dbContext.SaveChangesAsync();
        return new GeneralResponse(true, "Successfully saved");
    }
}
