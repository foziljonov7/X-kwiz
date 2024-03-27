namespace Kwiz.Domain.Entities;

public class Technology
{
    public long Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] Tags { get; set; }
}
