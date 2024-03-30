using System.ComponentModel.DataAnnotations;

namespace Kwiz.DataAccess.DTOs;

public class QuizDTO
{
    public Guid OwnerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsPublic { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public string[] Tags { get; set; }
    public string Code { get; set; }
}
