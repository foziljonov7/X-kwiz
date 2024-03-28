using System.ComponentModel.DataAnnotations;

namespace Kwiz.Domain.Entities;

public class Question
{
    [Key]
    public Guid Id { get; set; }
    [Required, MaxLength(250)]
    public string Content { get; set; }
    public string[] Tags { get; set; }
    [Required]
    public Guid QuizId { get; set; }
    public List<QuestionOptions> Options { get; set; }
    public Quiz Quiz { get; set; }
}
