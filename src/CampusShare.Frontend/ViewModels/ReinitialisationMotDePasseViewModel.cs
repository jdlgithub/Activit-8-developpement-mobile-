using CampusShare.Frontend.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampusShare.Frontend.ViewModels;

public partial class ReinitialisationMotDePasseViewModel : ObservableObject
{
    private readonly INavigationService _navigation;

    public ReinitialisationMotDePasseViewModel(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public string Titre => "Reinitialiser le mot de passe";

    [ObservableProperty]
    private string nouveauMotDePasse = string.Empty;

    [ObservableProperty]
    private string confirmation = string.Empty;

    [RelayCommand]
    private Task Valider() => _navigation.AllerVers(AppRoutes.Connexion);

    [RelayCommand]
    private Task Retour() => _navigation.Revenir();
}
