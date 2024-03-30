using Kwiz.DataAccess.Data;
using Kwiz.DataAccess.DTOs;
using Kwiz.Domain.Entities;
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
    public Task<GeneralResponse> CreateQuizAsync(QuizDTO newQuiz)
    {
        throw new NotImplementedException();
    }

    public Task<Quiz> GetQuizAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Quiz>> GetQuizzesAsync()
        => await dbContext.Quizzes
            .Include(q => q.Owner)
            .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
            .Include(q => q.Submissions)
            .ToListAsync();

    public Task<GeneralResponse> RemoveQuizAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<GeneralResponse> UpdateQuizAsync(Guid id, QuizDTO quiz)
    {
        throw new NotImplementedException();
    }
}
