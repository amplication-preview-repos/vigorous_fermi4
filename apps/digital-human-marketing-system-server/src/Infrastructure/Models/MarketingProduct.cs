using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace .Infrastructure.Models;

[Table("MarketingProducts")]
public class MarketingProductDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public string? DigitalHumanId { get; set; }

    [ForeignKey(nameof(DigitalHumanId))]
    public DigitalHumanDbModel? DigitalHuman { get; set; } = null;

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? ProductImage { get; set; }

    [StringLength(1000)]
    public string? ProductName { get; set; }

    [StringLength(1000)]
    public string? PurchaseLink { get; set; }

    [StringLength(1000)]
    public string? RecommendedWords { get; set; }

    [StringLength(1000)]
    public string? TargetAudience { get; set; }

    [StringLength(1000)]
    public string? Title { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
