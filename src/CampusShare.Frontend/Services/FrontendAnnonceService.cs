using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Frontend.Services;

public sealed class FrontendAnnonceService : IAnnonceService
{
    private readonly IAnnonceService _annonce;

    public FrontendAnnonceService(IAnnonceService annonce)
    {
        _annonce = annonce;
    }

    public ObjetDTO Publier(NouvelleAnnonceDTO annonce)
    {
        return _annonce.Publier(annonce);
    }

    public IEnumerable<ObjetDTO> ListerMesAnnonces()
    {
        return _annonce.ListerMesAnnonces();
    }

    public ObjetDTO Modifier(string objetId, NouvelleAnnonceDTO annonce)
    {
        return _annonce.Modifier(objetId, annonce);
    }

    public void Supprimer(string objetId)
    {
        _annonce.Supprimer(objetId);
    }
}
