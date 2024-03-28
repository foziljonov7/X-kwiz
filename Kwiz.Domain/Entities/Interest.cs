using System.ComponentModel.DataAnnotations;

namespace Kwiz.Domain.Entities;

public class Interest
{
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [Required]
    public List<Technology> InterestedTechnologies { get; set; }
}
