using Kwiz.DataAccess.Data;
using Kwiz.DataAccess.DTOs;
using Kwiz.Domain.Entities;
using Kwiz.Domain.Enums;
using Kwiz.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Kwiz.Infrastructure.Repositories;
public class QuizRepository : IQuizRepository
{
    private readonly IHttpContextAccessor httpContext;
    private readonly AppDbContext dbContext;

    public QuizRepository(IHttpContextAccessor httpContext,
        AppDbContext dbContext)
    {
        this.httpContext = httpContext;
        this.dbContext = dbContext;
    }
    public async Task<GeneralResponse> CreateQuizAsync(QuizDTO newQuiz)
    {
        var userId = httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userId, out Guid ownerId))
            return new GeneralResponse(false, "Invalid user identifier format");

        var quiz = new Quiz
        {
            Id = Guid.NewGuid(),
            OwnerId = ownerId,
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

    public async Task<IEnumerable<Quiz>> GetByNamesAsync(string name)
        => await dbContext.Quizzes
            .AsNoTracking()
            .Where(q => q.Title == name && q.Status == Status.Active)
            .ToListAsync();

    public async Task<Quiz> GetQuizAsync(Guid id)
    {
        var quiz = await dbContext.Quizzes
            .Where(q => q.Id == id)
            .Include(q => q.Owner)
            .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
            .Include(q => q.Submissions)
            .FirstOrDefaultAsync();

        if (quiz is null || quiz.Status is Status.Deleted)
            throw new NotSupportedException("Reference is null or there is some kind of interruption");

        return quiz;
    }

    public async Task<IEnumerable<Quiz>> GetQuizzesAsync()
        => await dbContext.Quizzes
            .Where(q => q.Status == Status.Active)
            .Include(q => q.Owner)
            .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
            .Include(q => q.Submissions)
            .ToListAsync();

    public async Task<List<Quiz>> GetQuizzesByDisableAsync(Guid ownerId)
        => await dbContext.Quizzes
            .Where(q => q.OwnerId == ownerId && q.Status == Status.Disable)
            .Include(q => q.Questions)
            .ToListAsync();

    public async Task<IEnumerable<Quiz>> GetQuizzesByOwnerIdAsync(Guid ownerId)
        => await dbContext.Quizzes
            .Where(q => q.OwnerId == ownerId && q.Status == Status.Active)
            .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
            .Include(q => q.Submissions)
            .ToListAsync();

    public async Task<GeneralResponse> RemoveQuizAsync(Guid id, Guid ownerId)
    {
        var quiz = await dbContext.Quizzes
            .FirstOrDefaultAsync(q => q.Id == id);

        if (quiz is null || quiz.Status is Status.Disable)
            return new GeneralResponse(false, "Quiz not found");

        quiz.Status = Status.Deleted;
        await dbContext.SaveChangesAsync();
        return new GeneralResponse(true, "Successfully deleted");
    }

    public async Task<GeneralResponse> UpdateQuizAsync(
            Guid id,
            Guid ownerId,
            QuizDTO quiz)
    {
        var updated = await dbContext.Quizzes
            .FirstOrDefaultAsync(q => q.Id == id && q.OwnerId == ownerId);

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
