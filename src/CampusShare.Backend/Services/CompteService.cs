using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Data;
using CampusShare.Backend.Errors;
using CampusShare.Backend.Models;

namespace CampusShare.Backend.Services;

public class CompteService : ICompteService
{
    private readonly JsonStore _store;
    private readonly SessionCourante _session;

    public CompteService(JsonStore store, SessionCourante session)
    {
        _store = store;
        _session = session;
    }

    public UtilisateurDTO SInscrire(DemandeInscription demande)
    {
        if (demande is null)
        {
            throw new BusinessException(BusinessErrorCode.ChampInvalide);
        }

        Validation.ExigerTexte(demande.Nom);
        Validation.ExigerTexte(demande.Prenom);
        Validation.ExigerTexte(demande.MotDePasse);
        Validation.ExigerTexte(demande.Filiere);
        Validation.ExigerTexte(demande.NiveauEtudes);
        Validation.ExigerEmailUniversitaire(demande.Email);

        if (TrouverParEmail(demande.Email) is not null)
        {
            throw new BusinessException(BusinessErrorCode.EmailDejaUtilise);
        }

        var utilisateur = new Utilisateur
        {
            Id = Identifiants.Prochain("u", _store.Utilisateurs.Select(u => u.Id)),
            Nom = demande.Nom,
            Prenom = demande.Prenom,
            Email = demande.Email,
            MotDePasse = demande.MotDePasse,
            Filiere = demande.Filiere,
            NiveauEtudes = demande.NiveauEtudes,
            AvatarInitiales = Validation.CalculerInitiales(demande.Prenom, demande.Nom),
            ScoreConfiance = 0m,
            NbEchanges = 0
        };

        _store.Utilisateurs.Add(utilisateur);
        _store.Sauvegarder();
        _session.Ouvrir(utilisateur.Id);
        return MappingVersDto.VersUtilisateur(utilisateur);
    }

    public SessionDTO SeConnecter(string email, string motDePasse)
    {
        var utilisateur = _store.Utilisateurs.FirstOrDefault(candidat =>
            string.Equals(candidat.Email, email, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(candidat.MotDePasse, motDePasse, StringComparison.Ordinal));

        if (utilisateur is null)
        {
            throw new BusinessException(BusinessErrorCode.IdentifiantsInvalides);
        }

        _session.Ouvrir(utilisateur.Id);
        return new SessionDTO
        {
            UtilisateurId = utilisateur.Id,
            NomAffiche = MappingVersDto.NomAffiche(utilisateur),
            AvatarInitiales = utilisateur.AvatarInitiales
        };
    }

    public bool MotDePasseOublie(string email)
    {
        Validation.ExigerEmailUniversitaire(email);
        return true;
    }

    public bool ReinitialiserMotDePasse(string email, string nouveauMotDePasse, string confirmation)
    {
        Validation.ExigerEmailUniversitaire(email);
        Validation.ExigerConfirmationIdentique(nouveauMotDePasse, confirmation);

        var utilisateur = TrouverParEmail(email);
        if (utilisateur is null)
        {
            return false;
        }

        utilisateur.MotDePasse = nouveauMotDePasse;
        _store.Sauvegarder();
        return true;
    }

    public void SeDeconnecter()
    {
        _session.Fermer();
    }

    private Utilisateur? TrouverParEmail(string email)
    {
        return _store.Utilisateurs.FirstOrDefault(utilisateur =>
            string.Equals(utilisateur.Email, email, StringComparison.OrdinalIgnoreCase));
    }
}
