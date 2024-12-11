namespace .APIs.Dtos;

public class MarketingProductCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public DigitalHuman? DigitalHuman { get; set; }

    public string? Id { get; set; }

    public string? ProductImage { get; set; }

    public string? ProductName { get; set; }

    public string? PurchaseLink { get; set; }

    public string? RecommendedWords { get; set; }

    public string? TargetAudience { get; set; }

    public string? Title { get; set; }

    public DateTime UpdatedAt { get; set; }
}
