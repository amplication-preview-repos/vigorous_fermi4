namespace .APIs.Dtos;

public class BusinessAccountCreateInput
{
    public string? BusinessName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<DigitalHuman>? DigitalHumen { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }
}
