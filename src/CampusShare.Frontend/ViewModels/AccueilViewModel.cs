using CampusShare.Frontend.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampusShare.Frontend.ViewModels;

public partial class AccueilViewModel : ObservableObject
{
    private readonly INavigationService _navigation;

    public AccueilViewModel(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public string Titre => "Bienvenue sur CampusShare";

    public string SousTitre => "Partagez et empruntez du materiel entre etudiants.";

    [RelayCommand]
    private Task SeConnecter() => _navigation.AllerVers(AppRoutes.Connexion);

    [RelayCommand]
    private Task SInscrire() => _navigation.AllerVers(AppRoutes.Inscription);
}
