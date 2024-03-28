using System.ComponentModel.DataAnnotations;

namespace Kwiz.Domain.Entities;

public class SubmissionSelection
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public Guid QuestionId { get; set; }
    public bool IsSkipped { get; set; }
    public int TimeSpentOnQuestion { get; set; }
    public List<QuestionOptions> SelectedOptions { get; set; }
    public Question Question { get; set; }
}
