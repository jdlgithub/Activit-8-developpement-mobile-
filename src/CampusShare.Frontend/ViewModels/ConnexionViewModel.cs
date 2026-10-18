using CampusShare.Frontend.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampusShare.Frontend.ViewModels;

public partial class ConnexionViewModel : ObservableObject
{
    private readonly INavigationService _navigation;

    public ConnexionViewModel(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public string Titre => "Connexion";

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string motDePasse = string.Empty;

    [RelayCommand]
    private Task SeConnecter() => _navigation.AllerVers(AppRoutes.TableauDeBord);

    [RelayCommand]
    private Task MotDePasseOublie() => _navigation.AllerVers(AppRoutes.MotDePasseOublie);

    [RelayCommand]
    private Task SInscrire() => _navigation.AllerVers(AppRoutes.Inscription);

    [RelayCommand]
    private Task Retour() => _navigation.Revenir();
}
