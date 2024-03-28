using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Kwiz.Domain.Entities;

public class QuestionOptions
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public Guid QuestionId { get; set; }
    [Required, MaxLength(250)]
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
    public bool IsRequired { get; set; }
    public string Explanation { get; set; }
}
