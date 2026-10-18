using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Backend.Contracts;

public interface IAnnonceService
{
    ObjetDTO Publier(NouvelleAnnonceDTO annonce);

    IEnumerable<ObjetDTO> ListerMesAnnonces();

    ObjetDTO Modifier(string objetId, NouvelleAnnonceDTO annonce);

    void Supprimer(string objetId);
}
