using Kwiz.DataAccess.DTOs;
using Kwiz.Domain.Entities;
using Kwiz.Infrastructure.Helpers;

namespace Kwiz.Infrastructure.Repositories;

public interface IQuizRepository
{
    Task<IEnumerable<Quiz>> GetQuizzesAsync();
    Task<Quiz> GetQuizAsync(Guid id);
    Task<IEnumerable<Quiz>> GetByNamesAsync(string name);
    Task<GeneralResponse> CreateQuizAsync(QuizDTO newQuiz);
    Task<GeneralResponse> UpdateQuizAsync(Guid id, QuizDTO quiz);
    Task<GeneralResponse> RemoveQuizAsync(Guid id);
}
