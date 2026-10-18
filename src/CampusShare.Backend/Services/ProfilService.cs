using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Data;
using CampusShare.Backend.Errors;

namespace CampusShare.Backend.Services;

public class ProfilService : IProfilService
{
    private readonly JsonStore _store;
    private readonly SessionCourante _session;

    public ProfilService(JsonStore store, SessionCourante session)
    {
        _store = store;
        _session = session;
    }

    public ProfilDTO ConsulterProfil()
    {
        var utilisateurId = Validation.ExigerUtilisateurConnecte(_session);
        var utilisateur = _store.Utilisateurs.FirstOrDefault(candidat => candidat.Id == utilisateurId);

        if (utilisateur is null)
        {
            throw new BusinessException(BusinessErrorCode.NonConnecte);
        }

        return MappingVersDto.VersProfil(utilisateur);
    }
}
