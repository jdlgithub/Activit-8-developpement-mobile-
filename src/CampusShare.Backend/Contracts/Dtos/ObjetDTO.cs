using CampusShare.Backend.Models;

namespace CampusShare.Backend.Contracts.Dtos;

public class ObjetDTO
{
    public string Id { get; set; } = string.Empty;

    public string Titre { get; set; } = string.Empty;

    public string Categorie { get; set; } = string.Empty;

    public EtatObjet Etat { get; set; }

    public string ProprietaireNom { get; set; } = string.Empty;

    public string ProprietaireInitiales { get; set; } = string.Empty;
}
