using Kwiz.DataAccess.DTOs;
using Kwiz.Domain.Entities;
using Kwiz.Infrastructure.Helpers;

namespace Kwiz.Infrastructure.Repositories;
public interface IQuestionOptionRepository
{
    Task<IEnumerable<QuestionOptions>> GetQuestionOptionsAsync();
    Task<QuestionOptions> GetQuestionOptionAsync(Guid id);
    Task<GeneralResponse> CreateQuestionOptionAsnc(QuestionOptionsDTO newOption);
    Task<GeneralResponse> UpdateQuestionOptionAsync(Guid id, QuestionOptionsDTO option);
    Task<GeneralResponse> DeleteQuestionOptionAsync(Guid id);
}
