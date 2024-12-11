namespace .APIs.Dtos;

public class DigitalHumanCreateInput
{
    public BusinessAccount? BusinessAccount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public List<DigitalHumanKnowledgeBase>? DigitalHumanKnowledgeBases { get; set; }

    public List<DigitalHumanStats>? DigitalHumanStatsItems { get; set; }

    public string? Id { get; set; }

    public List<MarketingProduct>? MarketingProducts { get; set; }

    public string? Name { get; set; }

    public string? PresentationVideos { get; set; }

    public string? StandbyVideos { get; set; }

    public DateTime UpdatedAt { get; set; }
}
