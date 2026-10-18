using CampusShare.Backend.Models;

namespace CampusShare.Backend.Contracts.Dtos;

public class DemandePretDTO
{
    public string ObjetId { get; set; } = string.Empty;

    public string ObjetTitre { get; set; } = string.Empty;

    public string ProprietaireNom { get; set; } = string.Empty;

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public string Message { get; set; } = string.Empty;

    public StatutDemande Statut { get; set; }
}
