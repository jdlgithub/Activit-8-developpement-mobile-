namespace CampusShare.Backend.Services;

public class SessionCourante
{
    public string? UtilisateurId { get; private set; }

    public bool EstConnecte => UtilisateurId is not null;

    public void Ouvrir(string utilisateurId)
    {
        UtilisateurId = utilisateurId;
    }

    public void Fermer()
    {
        UtilisateurId = null;
    }
}
