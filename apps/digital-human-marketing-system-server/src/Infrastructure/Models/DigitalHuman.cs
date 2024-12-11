using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace .Infrastructure.Models;

[Table("DigitalHumen")]
public class DigitalHumanDbModel
{
    public string? BusinessAccountId { get; set; }

    [ForeignKey(nameof(BusinessAccountId))]
    public BusinessAccountDbModel? BusinessAccount { get; set; } = null;

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public List<DigitalHumanKnowledgeBaseDbModel>? DigitalHumanKnowledgeBases { get; set; } = new List<DigitalHumanKnowledgeBaseDbModel>();

    public List<DigitalHumanStatsDbModel>? DigitalHumanStatsItems { get; set; } = new List<DigitalHumanStatsDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<MarketingProductDbModel>? MarketingProducts { get; set; } = new List<MarketingProductDbModel>();

    [StringLength(1000)]
    public string? Name { get; set; }

    public string? PresentationVideos { get; set; }

    public string? StandbyVideos { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
