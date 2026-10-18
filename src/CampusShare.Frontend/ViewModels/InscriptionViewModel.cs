using CampusShare.Frontend.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampusShare.Frontend.ViewModels;

public partial class InscriptionViewModel : ObservableObject
{
    private readonly INavigationService _navigation;

    public InscriptionViewModel(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public string Titre => "Creer un compte";

    [ObservableProperty]
    private string nom = string.Empty;

    [ObservableProperty]
    private string prenom = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string motDePasse = string.Empty;

    [ObservableProperty]
    private string filiere = string.Empty;

    [ObservableProperty]
    private string niveauEtudes = string.Empty;

    [RelayCommand]
    private Task Valider() => _navigation.AllerVers(AppRoutes.TableauDeBord);

    [RelayCommand]
    private Task Retour() => _navigation.Revenir();
}
