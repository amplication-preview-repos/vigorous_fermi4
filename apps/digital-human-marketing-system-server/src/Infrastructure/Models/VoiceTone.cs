using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace .Infrastructure.Models;

[Table("VoiceTones")]
public class VoiceToneDbModel
{
    public string? AudioFile { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? TextSummary { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
