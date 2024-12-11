using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace .Infrastructure.Models;

[Table("BusinessAccounts")]
public class BusinessAccountDbModel
{
    [StringLength(1000)]
    public string? BusinessName { get; set; }

    public string? ContactEmail { get; set; }

    [StringLength(1000)]
    public string? ContactPhone { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public List<DigitalHumanDbModel>? DigitalHumen { get; set; } = new List<DigitalHumanDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
