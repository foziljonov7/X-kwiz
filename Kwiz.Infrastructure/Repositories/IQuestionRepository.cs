using Kwiz.DataAccess.DTOs;
using Kwiz.Domain.Entities;
using Kwiz.Infrastructure.Helpers;

namespace Kwiz.Infrastructure.Repositories;
public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetQuestionsAsync();
    Task<Question> GetQuestionAsync(Guid id);
    Task<GeneralResponse> CreateQuestionAsync(QuestionDTO newQuestion);
    Task<GeneralResponse> UpdateQuestionAsync(Guid id, QuestionDTO question);
    Task<GeneralResponse> RemoveQuestionAsync(Guid id);
}
