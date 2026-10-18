using System.Collections.ObjectModel;
using CampusShare.Frontend.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampusShare.Frontend.ViewModels;

public partial class PublicationViewModel : ObservableObject
{
    private readonly INavigationService _navigation;

    public PublicationViewModel(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public string Titre => "Publier un objet";

    [ObservableProperty]
    private string titreObjet = string.Empty;

    [ObservableProperty]
    private string categorie = string.Empty;

    [ObservableProperty]
    private string description = string.Empty;

    [ObservableProperty]
    private string conditionsPret = string.Empty;

    [ObservableProperty]
    private string bati = string.Empty;

    public ObservableCollection<string> Photos { get; } = new();

    [RelayCommand]
    private Task Publier() => _navigation.Revenir();

    [RelayCommand]
    private Task Retour() => _navigation.Revenir();
}
