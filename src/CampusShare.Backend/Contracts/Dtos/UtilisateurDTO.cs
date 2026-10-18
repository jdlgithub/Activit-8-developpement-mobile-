namespace CampusShare.Backend.Contracts.Dtos;

public class UtilisateurDTO
{
    public string Id { get; set; } = string.Empty;

    public string Nom { get; set; } = string.Empty;

    public string Prenom { get; set; } = string.Empty;

    public string AvatarInitiales { get; set; } = string.Empty;

    public decimal ScoreConfiance { get; set; }

    public int NbEchanges { get; set; }
}
