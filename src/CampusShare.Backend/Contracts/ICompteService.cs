using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Backend.Contracts;

public interface ICompteService
{
    UtilisateurDTO SInscrire(DemandeInscription demande);

    SessionDTO SeConnecter(string email, string motDePasse);

    bool MotDePasseOublie(string email);

    bool ReinitialiserMotDePasse(string email, string nouveauMotDePasse, string confirmation);

    void SeDeconnecter();
}
