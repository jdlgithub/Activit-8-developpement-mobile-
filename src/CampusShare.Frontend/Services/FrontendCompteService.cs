using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Frontend.Services;

public sealed class FrontendCompteService : ICompteService
{
    private readonly ICompteService _compte;

    public FrontendCompteService(ICompteService compte)
    {
        _compte = compte;
    }

    public UtilisateurDTO SInscrire(DemandeInscription demande)
    {
        return _compte.SInscrire(demande);
    }

    public SessionDTO SeConnecter(string email, string motDePasse)
    {
        return _compte.SeConnecter(email, motDePasse);
    }

    public bool MotDePasseOublie(string email)
    {
        return _compte.MotDePasseOublie(email);
    }

    public bool ReinitialiserMotDePasse(string email, string nouveauMotDePasse, string confirmation)
    {
        return _compte.ReinitialiserMotDePasse(email, nouveauMotDePasse, confirmation);
    }

    public void SeDeconnecter()
    {
        _compte.SeDeconnecter();
    }
}
