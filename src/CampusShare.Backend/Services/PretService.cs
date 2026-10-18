using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Data;
using CampusShare.Backend.Errors;
using CampusShare.Backend.Models;

namespace CampusShare.Backend.Services;

public class PretService : IPretService
{
    private readonly JsonStore _store;
    private readonly SessionCourante _session;

    public PretService(JsonStore store, SessionCourante session)
    {
        _store = store;
        _session = session;
    }

    public DemandePretDTO Demander(DemandePretDTO demande)
    {
        var demandeurId = Validation.ExigerUtilisateurConnecte(_session);

        if (demande is null)
        {
            throw new BusinessException(BusinessErrorCode.ChampInvalide);
        }

        var objet = _store.Objets.FirstOrDefault(candidat => candidat.Id == demande.ObjetId);
        if (objet is null)
        {
            throw new BusinessException(BusinessErrorCode.ObjetIntrouvable);
        }

        if (string.Equals(objet.ProprietaireId, demandeurId, StringComparison.Ordinal))
        {
            throw new BusinessException(BusinessErrorCode.AutoPretInterdit);
        }

        if (objet.Etat != EtatObjet.Disponible)
        {
            throw new BusinessException(BusinessErrorCode.ObjetIndisponible);
        }

        if (demande.DateFin <= demande.DateDebut)
        {
            throw new BusinessException(BusinessErrorCode.DatesIncoherentes);
        }

        var entite = new DemandePret
        {
            Id = Identifiants.Prochain("d", _store.DemandesPret.Select(d => d.Id)),
            ObjetId = objet.Id,
            DemandeurId = demandeurId,
            ProprietaireId = objet.ProprietaireId,
            DateDebut = demande.DateDebut,
            DateFin = demande.DateFin,
            Message = demande.Message,
            Statut = StatutDemande.Envoyee
        };

        _store.DemandesPret.Add(entite);
        _store.Sauvegarder();
        return VersDto(entite);
    }

    public IEnumerable<DemandePretDTO> ListerMesEmprunts()
    {
        var demandeurId = Validation.ExigerUtilisateurConnecte(_session);

        return _store.DemandesPret
            .Where(demande => demande.DemandeurId == demandeurId)
            .OrderByDescending(demande => demande.DateDebut)
            .Select(VersDto)
            .ToList();
    }

    private DemandePretDTO VersDto(DemandePret demande)
    {
        var objet = _store.Objets.FirstOrDefault(candidat => candidat.Id == demande.ObjetId);
        var proprietaire = _store.Utilisateurs.FirstOrDefault(utilisateur => utilisateur.Id == demande.ProprietaireId);
        return MappingVersDto.VersDemande(demande, objet, proprietaire);
    }
}
