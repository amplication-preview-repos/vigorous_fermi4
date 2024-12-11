namespace .APIs.Dtos;

public class DigitalHumanKnowledgeBaseCreateInput
{
    public DateTime CreatedAt { get; set; }

    public DigitalHuman? DigitalHuman { get; set; }

    public string? DocumentLink { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }
}
