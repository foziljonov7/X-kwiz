namespace Kwiz.Domain.Entities;

public class Interest
{
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Technology> InterestedTechnologies { get; set; }
}
