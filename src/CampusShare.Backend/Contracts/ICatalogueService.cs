using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Backend.Contracts;

public interface ICatalogueService
{
    IEnumerable<ObjetDTO> Rechercher(string motCle, string? categorie);

    ObjetDetailDTO ConsulterObjet(string objetId);

    IEnumerable<string> ListerCategories();
}
