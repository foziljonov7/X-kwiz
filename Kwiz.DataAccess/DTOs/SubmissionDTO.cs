namespace Kwiz.DataAccess.DTOs;

public class SubmissionDTO
{
    public Guid OwnerId { get; set; }
    public Guid QuizId { get; set; }
    public DateTime StartedDate { get; set; }
    public DateTime FinishedDate { get; set; }
}
