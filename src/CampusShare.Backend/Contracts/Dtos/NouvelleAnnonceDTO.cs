namespace CampusShare.Backend.Contracts.Dtos;

public class NouvelleAnnonceDTO
{
    public string Titre { get; set; } = string.Empty;

    public string Categorie { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ConditionsPret { get; set; } = string.Empty;

    public string Bati { get; set; } = string.Empty;

    public List<string> Photos { get; set; } = new();
}
