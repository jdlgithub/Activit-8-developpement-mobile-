namespace CampusShare.Backend.Models;

public class Utilisateur
{
    public string Id { get; set; } = string.Empty;

    public string Nom { get; set; } = string.Empty;

    public string Prenom { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MotDePasse { get; set; } = string.Empty;

    public string Filiere { get; set; } = string.Empty;

    public string NiveauEtudes { get; set; } = string.Empty;

    public string AvatarInitiales { get; set; } = string.Empty;

    public decimal ScoreConfiance { get; set; }

    public int NbEchanges { get; set; }
}
