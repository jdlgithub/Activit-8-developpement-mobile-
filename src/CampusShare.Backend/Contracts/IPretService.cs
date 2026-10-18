using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Backend.Contracts;

public interface IPretService
{
    DemandePretDTO Demander(DemandePretDTO demande);

    IEnumerable<DemandePretDTO> ListerMesEmprunts();
}
