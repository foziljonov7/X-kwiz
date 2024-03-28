using System.ComponentModel.DataAnnotations;

namespace Kwiz.Domain.Entities;

public class Technology
{
    [Key]
    public long Id { get; set; }
    public string Type { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public string[] Tags { get; set; }
    public Guid InterestId { get; set; }
    public Interest Interest { get; set; }
}
