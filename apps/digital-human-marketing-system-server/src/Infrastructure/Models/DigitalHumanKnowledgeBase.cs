using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace .Infrastructure.Models;

[Table("DigitalHumanKnowledgeBases")]
public class DigitalHumanKnowledgeBaseDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? DigitalHumanId { get; set; }

    [ForeignKey(nameof(DigitalHumanId))]
    public DigitalHumanDbModel? DigitalHuman { get; set; } = null;

    public string? DocumentLink { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
