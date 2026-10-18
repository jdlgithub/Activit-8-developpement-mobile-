using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Errors;
using CampusShare.Frontend.Errors;
using CampusShare.Frontend.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampusShare.Frontend.ViewModels;

public partial class ProfilViewModel : ObservableObject
{
    private readonly IProfilService _profil;
    private readonly INavigationService _navigation;

    public ProfilViewModel(IProfilService profil, INavigationService navigation)
    {
        _profil = profil;
        _navigation = navigation;
    }

    public string Titre => "Profil et annonces";

    [ObservableProperty]
    private ProfilDTO? profil;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AErreur))]
    private string? messageErreur;

    public bool AErreur => !string.IsNullOrEmpty(MessageErreur);

    [RelayCommand]
    private void Charger()
    {
        MessageErreur = null;

        try
        {
            Profil = _profil.ConsulterProfil();
        }
        catch (BusinessException exception)
        {
            MessageErreur = TraducteurErreur.Traduire(exception.Code);
        }
    }

    [RelayCommand]
    private Task Retour() => _navigation.Revenir();
}
