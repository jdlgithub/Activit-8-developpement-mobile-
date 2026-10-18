using CampusShare.Frontend.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampusShare.Frontend.ViewModels;

public partial class MotDePasseOublieViewModel : ObservableObject
{
    private readonly INavigationService _navigation;

    public MotDePasseOublieViewModel(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public string Titre => "Mot de passe oublie";

    [ObservableProperty]
    private string email = string.Empty;

    [RelayCommand]
    private Task Envoyer() => _navigation.AllerVers(AppRoutes.ReinitialisationMotDePasse);

    [RelayCommand]
    private Task Retour() => _navigation.Revenir();
}
