namespace Kwiz.Domain.Entities;

public class SubmissionSelection
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public bool IsSkipped { get; set; }
    public int TimeSpentOnQuestion { get; set; }
    public List<QuestionOptions> SelectedOptions { get; set; }
    public Question Question { get; set; }
}
