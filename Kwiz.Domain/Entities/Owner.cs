using System.ComponentModel.DataAnnotations;

namespace Kwiz.Domain.Entities;

public class Owner
{
    [Key]
    public Guid Id { get; set; }
    public List<Quiz> Quizzes { get; set; }
}
