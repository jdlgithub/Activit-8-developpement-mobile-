using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Data;
using CampusShare.Backend.Errors;
using CampusShare.Backend.Models;

namespace CampusShare.Backend.Services;

public class CatalogueService : ICatalogueService
{
    private readonly JsonStore _store;

    public CatalogueService(JsonStore store)
    {
        _store = store;
    }

    public IEnumerable<ObjetDTO> Rechercher(string motCle, string? categorie)
    {
        var resultats = _store.Objets.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(motCle))
        {
            var cle = motCle.Trim();
            resultats = resultats.Where(objet =>
                objet.Titre.Contains(cle, StringComparison.OrdinalIgnoreCase) ||
                objet.Description.Contains(cle, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(categorie))
        {
            resultats = resultats.Where(objet => string.Equals(objet.Categorie, categorie, StringComparison.OrdinalIgnoreCase));
        }

        return resultats.Select(objet => MappingVersDto.VersObjet(objet, Proprietaire(objet))).ToList();
    }

    public ObjetDetailDTO ConsulterObjet(string objetId)
    {
        var objet = _store.Objets.FirstOrDefault(o => o.Id == objetId);
        if (objet is null)
        {
            throw new BusinessException(BusinessErrorCode.ObjetIntrouvable);
        }

        return MappingVersDto.VersObjetDetail(objet, Proprietaire(objet));
    }

    public IEnumerable<string> ListerCategories()
    {
        return _store.Objets
            .Select(objet => objet.Categorie)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(categorie => categorie)
            .ToList();
    }

    private Utilisateur? Proprietaire(Objet objet)
    {
        return _store.Utilisateurs.FirstOrDefault(utilisateur => utilisateur.Id == objet.ProprietaireId);
    }
}
