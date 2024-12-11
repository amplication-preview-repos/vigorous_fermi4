namespace .APIs.Dtos;

public class BusinessAccountWhereInput
{
    public string? BusinessName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public List<string>? DigitalHumen { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
