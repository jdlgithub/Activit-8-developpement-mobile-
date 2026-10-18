using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Frontend.Services;

public sealed class FrontendPretService : IPretService
{
    private readonly IPretService _pret;

    public FrontendPretService(IPretService pret)
    {
        _pret = pret;
    }

    public DemandePretDTO Demander(DemandePretDTO demande)
    {
        return _pret.Demander(demande);
    }

    public IEnumerable<DemandePretDTO> ListerMesEmprunts()
    {
        return _pret.ListerMesEmprunts();
    }
}
