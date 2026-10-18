namespace CampusShare.Backend.Models;

public class DemandePret
{
    public string Id { get; set; } = string.Empty;

    public string ObjetId { get; set; } = string.Empty;

    public string DemandeurId { get; set; } = string.Empty;

    public string ProprietaireId { get; set; } = string.Empty;

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public string Message { get; set; } = string.Empty;

    public StatutDemande Statut { get; set; }
}
