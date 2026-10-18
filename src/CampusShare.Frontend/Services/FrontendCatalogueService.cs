using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Frontend.Services;

public sealed class FrontendCatalogueService : ICatalogueService
{
    private readonly ICatalogueService _catalogue;

    public FrontendCatalogueService(ICatalogueService catalogue)
    {
        _catalogue = catalogue;
    }

    public IEnumerable<ObjetDTO> Rechercher(string motCle, string? categorie)
    {
        return _catalogue.Rechercher(motCle, categorie);
    }

    public ObjetDetailDTO ConsulterObjet(string objetId)
    {
        return _catalogue.ConsulterObjet(objetId);
    }

    public IEnumerable<string> ListerCategories()
    {
        return _catalogue.ListerCategories();
    }
}
