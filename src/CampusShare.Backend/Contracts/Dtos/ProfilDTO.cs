namespace CampusShare.Backend.Contracts.Dtos;

public class ProfilDTO : UtilisateurDTO
{
    public string Filiere { get; set; } = string.Empty;

    public string NiveauEtudes { get; set; } = string.Empty;
}
