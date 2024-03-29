namespace Kwiz.DataAccess.DTOs;
public class QuestionDTO
{
    public string Content { get; set; }
    public string[] Tags { get; set; }
    public Guid QuizId { get; set; }
}
