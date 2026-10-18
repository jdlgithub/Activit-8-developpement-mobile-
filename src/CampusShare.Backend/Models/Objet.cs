namespace CampusShare.Backend.Models;

public class Objet
{
    public string Id { get; set; } = string.Empty;

    public string Titre { get; set; } = string.Empty;

    public string Categorie { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ConditionsPret { get; set; } = string.Empty;

    public EtatObjet Etat { get; set; }

    public string Bati { get; set; } = string.Empty;

    public List<string> Photos { get; set; } = new();

    public string ProprietaireId { get; set; } = string.Empty;
}
