namespace .APIs.Dtos;

public class DigitalHuman
{
    public string? BusinessAccount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public List<string>? DigitalHumanKnowledgeBases { get; set; }

    public List<string>? DigitalHumanStatsItems { get; set; }

    public string Id { get; set; }

    public List<string>? MarketingProducts { get; set; }

    public string? Name { get; set; }

    public string? PresentationVideos { get; set; }

    public string? StandbyVideos { get; set; }

    public DateTime UpdatedAt { get; set; }
}
