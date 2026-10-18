using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Models;

namespace CampusShare.Backend.Services;

public static class MappingVersDto
{
    public static string NomAffiche(Utilisateur utilisateur)
    {
        return $"{utilisateur.Prenom} {utilisateur.Nom}".Trim();
    }

    public static UtilisateurDTO VersUtilisateur(Utilisateur utilisateur) => new()
    {
        Id = utilisateur.Id,
        Nom = utilisateur.Nom,
        Prenom = utilisateur.Prenom,
        AvatarInitiales = utilisateur.AvatarInitiales,
        ScoreConfiance = utilisateur.ScoreConfiance,
        NbEchanges = utilisateur.NbEchanges
    };

    public static ProfilDTO VersProfil(Utilisateur utilisateur) => new()
    {
        Id = utilisateur.Id,
        Nom = utilisateur.Nom,
        Prenom = utilisateur.Prenom,
        AvatarInitiales = utilisateur.AvatarInitiales,
        ScoreConfiance = utilisateur.ScoreConfiance,
        NbEchanges = utilisateur.NbEchanges,
        Filiere = utilisateur.Filiere,
        NiveauEtudes = utilisateur.NiveauEtudes
    };

    public static ObjetDTO VersObjet(Objet objet, Utilisateur? proprietaire) => new()
    {
        Id = objet.Id,
        Titre = objet.Titre,
        Categorie = objet.Categorie,
        Etat = objet.Etat,
        ProprietaireNom = proprietaire is null ? string.Empty : NomAffiche(proprietaire),
        ProprietaireInitiales = proprietaire?.AvatarInitiales ?? string.Empty
    };

    public static ObjetDetailDTO VersObjetDetail(Objet objet, Utilisateur? proprietaire) => new()
    {
        Id = objet.Id,
        Titre = objet.Titre,
        Categorie = objet.Categorie,
        Etat = objet.Etat,
        ProprietaireNom = proprietaire is null ? string.Empty : NomAffiche(proprietaire),
        ProprietaireInitiales = proprietaire?.AvatarInitiales ?? string.Empty,
        Description = objet.Description,
        ConditionsPret = objet.ConditionsPret,
        Bati = objet.Bati,
        Photos = new List<string>(objet.Photos),
        ScoreConfiance = proprietaire?.ScoreConfiance ?? 0m
    };

    public static DemandePretDTO VersDemande(DemandePret demande, Objet? objet, Utilisateur? proprietaire) => new()
    {
        ObjetId = demande.ObjetId,
        ObjetTitre = objet?.Titre ?? string.Empty,
        ProprietaireNom = proprietaire is null ? string.Empty : NomAffiche(proprietaire),
        DateDebut = demande.DateDebut,
        DateFin = demande.DateFin,
        Message = demande.Message,
        Statut = demande.Statut
    };

    public static ConversationDTO VersConversation(Conversation conversation, Utilisateur? interlocuteur, Objet? objet) => new()
    {
        Id = conversation.Id,
        ParticipantNom = interlocuteur is null ? string.Empty : NomAffiche(interlocuteur),
        ParticipantInitiales = interlocuteur?.AvatarInitiales ?? string.Empty,
        ObjetTitre = objet?.Titre ?? string.Empty,
        DernierMessage = conversation.DernierMessage
    };

    public static MessageDTO VersMessage(Message message) => new()
    {
        Id = message.Id,
        EmetteurId = message.EmetteurId,
        Contenu = message.Contenu,
        Horodatage = message.Horodatage
    };
}
