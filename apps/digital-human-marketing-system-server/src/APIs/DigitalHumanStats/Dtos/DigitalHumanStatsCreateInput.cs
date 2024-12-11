namespace .APIs.Dtos;

public class DigitalHumanStatsCreateInput
{
    public int? ConversationCount { get; set; }

    public double? ConversationDuration { get; set; }

    public DateTime CreatedAt { get; set; }

    public DigitalHuman? DigitalHuman { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? ViewCount { get; set; }
}
