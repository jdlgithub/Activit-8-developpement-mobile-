using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Frontend.Services;

public sealed class FrontendProfilService : IProfilService
{
    private readonly IProfilService _profil;

    public FrontendProfilService(IProfilService profil)
    {
        _profil = profil;
    }

    public ProfilDTO ConsulterProfil()
    {
        return _profil.ConsulterProfil();
    }
}
