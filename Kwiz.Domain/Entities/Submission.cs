namespace Kwiz.Domain.Entities;

public class Submission
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public Guid QuizId { get; set; }
    public DateTime StartedDate { get; set; }
    public DateTime FinishedDate { get; set; }
    public Quiz Quiz { get; set; }
}
