using Kwiz.DataAccess.Data;
using Kwiz.DataAccess.DTOs;
using Kwiz.Domain.Entities;
using Kwiz.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Kwiz.Infrastructure.Repositories;

public class SubmissionRepository : ISubmissionRepository
{
    private readonly AppDbContext dbContext;

    public SubmissionRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<GeneralResponse> CreateSubmissionAsync(SubmissionDTO newSubmission)
    {
        var submission = new Submission
        {
            Id = Guid.NewGuid(),
            OwnerId = newSubmission.OwnerId,
            QuizId = newSubmission.QuizId,
            StartedDate = newSubmission.StartedDate,
            FinishedDate = newSubmission.FinishedDate
        };

        await dbContext.Submissions.AddAsync(submission);
        await dbContext.SaveChangesAsync();

        return new GeneralResponse(true, "Successfully saved");
    }

    public async Task<Submission> GetSubmissionAsync(Guid id)
    {
        var submission = await dbContext.Submissions
            .Include(s => s.Quiz)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (submission is null)
            throw new ArgumentException(nameof(id), "Submission is null");

        return submission;
    }

    public async Task<IEnumerable<Submission>> GetSubmissionByOwnerAsync(Guid ownerId)
    {
        var submission = await dbContext.Submissions
            .Where(s => s.OwnerId == ownerId)
            .Include(s => s.Quiz)
            .ToListAsync();

        if (submission is null)
            throw new ArgumentException(nameof(ownerId), "Submission is null");

        return submission;
    }

    public async Task<IEnumerable<Submission>> GetSubmissionsAsync()
        => await dbContext.Submissions
            .Include(s => s.Quiz)
            .ToListAsync();

    public async Task<GeneralResponse> UpdateSubmissionAsync(Guid id, SubmissionDTO submission)
    {
        var updated = await dbContext.Submissions
            .FirstOrDefaultAsync(s => s.Id == id);

        if (updated is null)
            return new GeneralResponse(false, "Submission is null");

        updated.OwnerId = submission.OwnerId;
        updated.QuizId = submission.QuizId;
        updated.StartedDate = submission.StartedDate;
        updated.FinishedDate = submission.FinishedDate;

        await dbContext.SaveChangesAsync();
        return new GeneralResponse(true, "Successfully saved");
    }
}
