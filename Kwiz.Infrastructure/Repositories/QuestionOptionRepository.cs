using Kwiz.DataAccess.Data;
using Kwiz.DataAccess.DTOs;
using Kwiz.Domain.Entities;
using Kwiz.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.Infrastructure.Repositories;

public class QuestionOptionRepository : IQuestionOptionRepository
{
    private readonly AppDbContext dbContext;
    public QuestionOptionRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<GeneralResponse> CreateQuestionOptionAsnc(QuestionOptionsDTO newOption)
    {
        var option = new QuestionOptions
        {
            Id = Guid.NewGuid(),
            QuestionId = newOption.QuestionId,
            Content = newOption.Content,
            IsCorrect = newOption.IsCorrect,
            IsRequired = newOption.IsRequired,
            Explanation = newOption.Explanation
        };

        await dbContext.Options.AddAsync(option);
        await dbContext.SaveChangesAsync();

        return new GeneralResponse(true, "Successfully saved");
    }

    public async Task<GeneralResponse> DeleteQuestionOptionAsync(Guid id)
    {
        var option = await dbContext.Options
            .FirstOrDefaultAsync(o => o.Id == id);

        if (option is null)
            return new GeneralResponse(false, "Invalid operation");

        dbContext.Options.Remove(option);
        return new GeneralResponse(true, "Successfully saved");
    }

    public async Task<QuestionOptions> GetQuestionOptionAsync(Guid id)
    {
        var option = await dbContext.Options
            .FirstOrDefaultAsync(q => q.Id == id);

        if (option is null)
            throw new ArgumentNullException(nameof(id), "Question option is null");

        return option;
    }

    public async Task<IEnumerable<QuestionOptions>> GetQuestionOptionsAsync(Guid questionId)
        => await dbContext.Options
            .Where(q => q.QuestionId == questionId)
            .ToListAsync();

    public async Task<GeneralResponse> UpdateQuestionOptionAsync(Guid id, QuestionOptionsDTO option)
    {
        var updateOption = await dbContext.Options
            .FirstOrDefaultAsync(o => o.Id == id);

        if (updateOption is null)
            return new GeneralResponse(false, "Invalid operation");

        updateOption.Content = option.Content;
        updateOption.QuestionId = option.QuestionId;
        updateOption.IsCorrect = option.IsCorrect;
        updateOption.IsRequired = option.IsRequired;
        updateOption.Explanation = option.Explanation;

        await dbContext.SaveChangesAsync();
        return new GeneralResponse(true, "Successfully saved");
    }
}
