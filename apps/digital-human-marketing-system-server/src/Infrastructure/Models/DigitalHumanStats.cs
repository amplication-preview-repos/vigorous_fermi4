using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace .Infrastructure.Models;

[Table("DigitalHumanStats")]
public class DigitalHumanStatsDbModel
{
    [Range(-999999999, 999999999)]
    public int? ConversationCount { get; set; }

    [Range(-999999999, 999999999)]
    public double? ConversationDuration { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? DigitalHumanId { get; set; }

    [ForeignKey(nameof(DigitalHumanId))]
    public DigitalHumanDbModel? DigitalHuman { get; set; } = null;

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Range(-999999999, 999999999)]
    public int? ViewCount { get; set; }
}
