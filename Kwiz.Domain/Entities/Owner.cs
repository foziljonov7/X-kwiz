namespace Kwiz.Domain.Entities;

public class Owner
{
    public Guid Id { get; set; }
    public List<Quiz> Quizzes { get; set; }
}
