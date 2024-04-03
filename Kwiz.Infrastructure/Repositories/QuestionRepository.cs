using Kwiz.DataAccess.Data;
using Kwiz.DataAccess.DTOs;
using Kwiz.Domain.Entities;
using Kwiz.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly AppDbContext dbContext;
    public QuestionRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<GeneralResponse> CreateQuestionAsync(QuestionDTO newQuestion)
    {
        var question = new Question
        {
            Id = Guid.NewGuid(),
            Content = newQuestion.Content,
            Tags = newQuestion.Tags,
            QuizId = newQuestion.QuizId
        };

        await dbContext.Questions.AddAsync(question);
        await dbContext.SaveChangesAsync();

        return new GeneralResponse(true, "Successfully saved");
    }

    public async Task<Question> GetQuestionAsync(Guid id)
    {
        var question = await dbContext.Questions
            .Where(q => q.Id == id)
            .Include(q => q.Quiz)
            .Include(q => q.Options)
            .FirstOrDefaultAsync();

        if (question is null)
            throw new ArgumentNullException(nameof(id), "Question is null");

        return question;
    }

    public async Task<IEnumerable<Question>> GetQuestionByQuizIdAsync(Guid quizId)
        => await dbContext.Questions
            .Where(q => q.QuizId == quizId)
            .Include(q => q.Quiz)
            .Include(q => q.Options)
            .ToListAsync();

    public async Task<IEnumerable<Question>> GetQuestionsAsync()
        => await dbContext.Questions
            .Include(q => q.Quiz)
            .Include(q => q.Options)
            .ToListAsync();
            
    public async Task<GeneralResponse> RemoveQuestionAsync(Guid id)
    {
        var question = await dbContext.Questions
            .FirstOrDefaultAsync(q => q.Id == id);

        if (question is null)
            return new GeneralResponse(false, "Question is null");

        dbContext.Questions.Remove(question);
        await dbContext.SaveChangesAsync();

        return new GeneralResponse(true, "Successfully deleted");
    }

    public async Task<GeneralResponse> UpdateQuestionAsync(Guid id, QuestionDTO question)
    {
        var updateQuestion = await dbContext.Questions
            .FirstOrDefaultAsync(q => q.Id == id);

        if (updateQuestion is null)
            return new GeneralResponse(false, "Question is null");

        updateQuestion.Content = question.Content;
        updateQuestion.Tags = question.Tags;
        updateQuestion.QuizId = question.QuizId;

        await dbContext.SaveChangesAsync();
        return new GeneralResponse(true, "Successfully updated");
    }
}
