namespace Kwiz.DataAccess.DTOs;

public class QuestionOptionsDTO
{
    public Guid QuestionId { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
    public bool IsRequired { get; set; }
    public string Explanation { get; set; }
}
