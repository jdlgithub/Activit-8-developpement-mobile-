using CampusShare.Frontend.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampusShare.Frontend.ViewModels;

public partial class DemandePretViewModel : ObservableObject
{
    private readonly INavigationService _navigation;

    public DemandePretViewModel(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public string Titre => "Demande de pret";

    [ObservableProperty]
    private DateTime dateDebut = DateTime.Today;

    [ObservableProperty]
    private DateTime dateFin = DateTime.Today.AddDays(7);

    [ObservableProperty]
    private string message = string.Empty;

    [RelayCommand]
    private Task Envoyer() => _navigation.Revenir();

    [RelayCommand]
    private Task Retour() => _navigation.Revenir();
}
