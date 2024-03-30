using Kwiz.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Kwiz.Domain.Entities;

public class Quiz
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public Guid OwnerId { get; set; }
    [Required, MaxLength(250)]
    public string Title { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public bool IsPublic { get; set; }
    public string[] Tags { get; set; }
    public string Code { get; set; }
    public Status Status { get; set; }
    public Owner Owner { get; set; }
    public List<Question> Questions { get; set; }
    public List<Submission> Submissions { get; set; }
}
