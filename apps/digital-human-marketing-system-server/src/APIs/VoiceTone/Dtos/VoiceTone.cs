namespace .APIs.Dtos;

public class VoiceTone
{
    public string? AudioFile { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public string? Name { get; set; }

    public string? TextSummary { get; set; }

    public DateTime UpdatedAt { get; set; }
}
