using Kwiz.DataAccess.DTOs;
using Kwiz.Domain.Entities;
using Kwiz.Infrastructure.Helpers;

namespace Kwiz.Infrastructure.Repositories;

public interface ISubmissionRepository
{
    Task<IEnumerable<Submission>> GetSubmissionsAsync();
    Task<Submission> GetSubmissionAsync(Guid id);
    Task<GeneralResponse> CreateSubmissionAsync(SubmissionDTO newSubmission);
    Task<GeneralResponse> UpdateSubmissionAsync(Guid id, SubmissionDTO submission);
    Task<IEnumerable<Submission>> GetSubmissionByOwnerAsync(Guid ownerId);
}
