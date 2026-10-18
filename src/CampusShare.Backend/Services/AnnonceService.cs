using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Data;
using CampusShare.Backend.Errors;
using CampusShare.Backend.Models;

namespace CampusShare.Backend.Services;

public class AnnonceService : IAnnonceService
{
    private readonly JsonStore _store;
    private readonly SessionCourante _session;

    public AnnonceService(JsonStore store, SessionCourante session)
    {
        _store = store;
        _session = session;
    }

    public ObjetDTO Publier(NouvelleAnnonceDTO annonce)
    {
        var proprietaireId = Validation.ExigerUtilisateurConnecte(_session);
        ValiderAnnonce(annonce);

        var objet = new Objet
        {
            Id = Identifiants.Prochain("o", _store.Objets.Select(o => o.Id)),
            Titre = annonce.Titre,
            Categorie = annonce.Categorie,
            Description = annonce.Description,
            ConditionsPret = annonce.ConditionsPret,
            Etat = EtatObjet.Disponible,
            Bati = annonce.Bati,
            Photos = annonce.Photos is null ? new List<string>() : new List<string>(annonce.Photos),
            ProprietaireId = proprietaireId
        };

        _store.Objets.Add(objet);
        _store.Sauvegarder();
        return VersDto(objet);
    }

    public IEnumerable<ObjetDTO> ListerMesAnnonces()
    {
        var proprietaireId = Validation.ExigerUtilisateurConnecte(_session);

        return _store.Objets
            .Where(objet => objet.ProprietaireId == proprietaireId)
            .Select(VersDto)
            .ToList();
    }

    public ObjetDTO Modifier(string objetId, NouvelleAnnonceDTO annonce)
    {
        var proprietaireId = Validation.ExigerUtilisateurConnecte(_session);
        ValiderAnnonce(annonce);

        var objet = Trouver(objetId, proprietaireId);
        objet.Titre = annonce.Titre;
        objet.Categorie = annonce.Categorie;
        objet.Description = annonce.Description;
        objet.ConditionsPret = annonce.ConditionsPret;
        objet.Bati = annonce.Bati;
        objet.Photos = annonce.Photos is null ? new List<string>() : new List<string>(annonce.Photos);

        _store.Sauvegarder();
        return VersDto(objet);
    }

    public void Supprimer(string objetId)
    {
        var proprietaireId = Validation.ExigerUtilisateurConnecte(_session);
        var objet = Trouver(objetId, proprietaireId);
        _store.Objets.Remove(objet);
        _store.Sauvegarder();
    }

    private void ValiderAnnonce(NouvelleAnnonceDTO? annonce)
    {
        if (annonce is null)
        {
            throw new BusinessException(BusinessErrorCode.ChampInvalide);
        }

        Validation.ExigerTexte(annonce.Titre);
        Validation.ExigerTexte(annonce.Categorie);
        Validation.ExigerTexte(annonce.Description);
        Validation.ExigerTexte(annonce.ConditionsPret);
        Validation.ExigerTexte(annonce.Bati);
        Validation.ExigerPhotosValides(annonce.Photos);
    }

    private Objet Trouver(string objetId, string proprietaireId)
    {
        var objet = _store.Objets.FirstOrDefault(candidat =>
            candidat.Id == objetId && candidat.ProprietaireId == proprietaireId);

        if (objet is null)
        {
            throw new BusinessException(BusinessErrorCode.ObjetIntrouvable);
        }

        return objet;
    }

    private ObjetDTO VersDto(Objet objet)
    {
        var proprietaire = _store.Utilisateurs.FirstOrDefault(utilisateur => utilisateur.Id == objet.ProprietaireId);
        return MappingVersDto.VersObjet(objet, proprietaire);
    }
}
