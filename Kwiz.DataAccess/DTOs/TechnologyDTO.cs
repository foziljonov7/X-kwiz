namespace Kwiz.DataAccess.DTOs;

public class TechnologyDTO
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] Tags { get; set; }
    public Guid InterestId { get; set; }
}
