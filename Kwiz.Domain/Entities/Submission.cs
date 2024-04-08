using Kwiz.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Kwiz.Domain.Entities;

public class Submission
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public Guid OwnerId { get; set; }
    [Required]
    public Guid QuizId { get; set; }
    public DateTime StartedDate { get; set; }
    public DateTime FinishedDate { get; set; }
    //public Status Status { get; set; }
    public Quiz Quiz { get; set; }
}
