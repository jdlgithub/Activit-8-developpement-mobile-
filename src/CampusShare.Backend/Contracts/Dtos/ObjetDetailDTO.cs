namespace CampusShare.Backend.Contracts.Dtos;

public class ObjetDetailDTO : ObjetDTO
{
    public string Description { get; set; } = string.Empty;

    public string ConditionsPret { get; set; } = string.Empty;

    public string Bati { get; set; } = string.Empty;

    public List<string> Photos { get; set; } = new();

    public decimal ScoreConfiance { get; set; }
}
