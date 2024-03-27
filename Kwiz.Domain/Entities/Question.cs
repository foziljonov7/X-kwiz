namespace Kwiz.Domain.Entities;

public class Question
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string[] Tags { get; set; }
    public List<QuestionOptions> Options { get; set; }
    public List<Quiz> Quizzes { get; set; }
}
